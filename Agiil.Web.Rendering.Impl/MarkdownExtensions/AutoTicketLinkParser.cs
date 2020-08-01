using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Web.Rendering.Tickets;
using Markdig.Helpers;
using Markdig.Parsers;
using Markdig.Renderers.Html;
using Markdig.Syntax.Inlines;

namespace Agiil.Web.Rendering.MarkdownExtensions
{
    public class AutoTicketLinkParser : InlineParser
    {
        const string TicketLinkClass = "ticket_link";

        readonly IParsesTicketReferenceFromMarkdigCharIterator referenceParser;
        readonly Lazy<IGetsTicketUri> ticketUriProvider;

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            var previousChar = slice.PeekCharExtra(-1);
            if(!IsValidPreviousCharacter(previousChar)) return false;

            List<char> pendingEmphasis;
            if(!IsAutoLinkValidInCurrentContext(processor, out pendingEmphasis)) return false;

            int charactersConsumedInReference;
            var ticketUri = GetTicketUri(slice, out charactersConsumedInReference);
            if(ticketUri == null) return false;

            AddTicketLink(processor, slice, charactersConsumedInReference, ticketUri);
            slice.Start += charactersConsumedInReference;

            return true;
        }

        static void AddTicketLink(InlineProcessor processor,
                                  StringSlice slice,
                                  int charactersConsumedInReference,
                                  Uri uri)
        {
            int line, column;

            var startPosition = slice.Start;
            var endPosition = startPosition + charactersConsumedInReference - 1;
            var linkText = new StringSlice(slice.Text, startPosition, endPosition);

            var link = new TicketLinkInline {
                Span = {
                  Start = processor.GetSourcePosition(startPosition, out line, out column),
                },
                Line = line,
                Column = column,
                Url = uri.ToString(),
                IsClosed = true,
                IsAutoLink = true,
                Title = $"Navigate to {linkText.ToString()}",
            };

            link.Span.End = endPosition;
            link.UrlSpan = link.Span;
            link.GetAttributes().AddClass(TicketLinkClass);

            var linkContent = new LiteralInline {
                Span = link.Span,
                Line = line,
                Column = column,
                Content = linkText,
                IsClosed = true,
            };

            link.AppendChild(linkContent);

            processor.Inline = link;
        }

        Uri GetTicketUri(ICharIterator iterator, out int charactersConsumedInReference)
        {
            var ticketReference = referenceParser.GetTicketReference(iterator, out charactersConsumedInReference);
            if(ticketReference == null) return null;

            var ticketUri = ticketUriProvider.Value.GetAbsoluteUri(ticketReference);
            return ticketUri;
        }

        static bool IsValidPreviousCharacter(char c)
        {
            // An auto-ticket link can only come at the beginning of a line, after
            // whitespace, or any of the delimiting characters *, _, ~, and (.
            return c.IsWhiteSpaceOrZero() || c == '*' || c == '_' || c == '~' || c == '(';
        }

        // This entire method is taken from the following code
        // https://github.com/lunet-io/markdig/blob/0f7e3b8c5278442f2ec5965a8f2b2c9ee573227a/src/Markdig/Extensions/AutoLinks/AutoLinkParser.cs
        // The conditions on which a ticket link would be valid are the same as an auto-link.
        bool IsAutoLinkValidInCurrentContext(InlineProcessor processor, out List<char> pendingEmphasis)
        {
            pendingEmphasis = null;

            // Case where there is a pending HtmlInline <a>
            var currentInline = processor.Inline;
            while(currentInline != null)
            {
                var htmlInline = currentInline as HtmlInline;
                if(htmlInline != null)
                {
                    // If we have a </a> we don't expect nested <a>
                    if(htmlInline.Tag.StartsWith("</a", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    // If there is a pending <a>, we can't allow a link
                    if(htmlInline.Tag.StartsWith("<a", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }

                // Check previous sibling and parents in the tree 
                currentInline = currentInline.PreviousSibling ?? currentInline.Parent;
            }

            // Check that we don't have any pending brackets opened (where we could have a possible markdown link)
            // NOTE: This assume that [ and ] are used for links, otherwise autolink will not work properly
            currentInline = processor.Inline;
            int countBrackets = 0;
            while(currentInline != null)
            {
                var linkDelimiterInline = currentInline as LinkDelimiterInline;
                if(linkDelimiterInline != null && linkDelimiterInline.IsActive)
                {
                    if(linkDelimiterInline.Type == DelimiterType.Open)
                    {
                        countBrackets++;
                    }
                    else if(linkDelimiterInline.Type == DelimiterType.Close)
                    {
                        countBrackets--;
                    }
                }
                else
                {
                    // Record all pending characters for emphasis
                    var emphasisDelimiter = currentInline as EmphasisDelimiterInline;
                    if(emphasisDelimiter != null)
                    {
                        if(pendingEmphasis == null)
                        {
                            // Not optimized for GC, but we don't expect this case much
                            pendingEmphasis = new List<char>();
                        }
                        if(!pendingEmphasis.Contains(emphasisDelimiter.DelimiterChar))
                        {
                            pendingEmphasis.Add(emphasisDelimiter.DelimiterChar);
                        }
                    }
                }
                currentInline = currentInline.Parent;
            }

            return countBrackets <= 0;
        }

        public AutoTicketLinkParser(IParsesTicketReferenceFromMarkdigCharIterator referenceParser,
                                    Lazy<IGetsTicketUri> ticketUriProvider)
        {
            this.referenceParser = referenceParser ?? throw new ArgumentNullException(nameof(referenceParser));
            this.ticketUriProvider = ticketUriProvider ?? throw new ArgumentNullException(nameof(ticketUriProvider));

            OpeningCharacters = new[] { '#' };
        }
    }
}
