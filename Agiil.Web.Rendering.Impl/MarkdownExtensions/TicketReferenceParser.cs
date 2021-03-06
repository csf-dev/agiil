﻿using System;
using Agiil.Domain.Tickets;
using Markdig.Helpers;

namespace Agiil.Web.Rendering.MarkdownExtensions
{
    public class TicketReferenceParser : IParsesTicketReferenceFromMarkdigCharIterator
    {
        const char BeginningCharacter = '#';

        readonly IParsesTicketReference referenceParser;

        public TicketReference GetTicketReference(ICharIterator iterator, out int charactersConsumed)
        {
            var refString = GetCandidateTicketReference(iterator, out charactersConsumed);

            if(String.IsNullOrEmpty(refString))
            {
                charactersConsumed = 0;
                return null;
            }

            var ticketRef = referenceParser.ParseReferece(refString);
            if(ticketRef == null)
            {
                charactersConsumed = 0;
                return null;
            }

            return ticketRef;
        }

        /// <summary>
        /// Gets a candidate for a ticket reference string.  This isn't a full parsing operation; it only looks for strings
        /// which look like they might be valid.
        /// </summary>
        /// <returns>The candidate ticket reference.</returns>
        /// <param name="iterator">Iterator.</param>
        /// <param name="charactersConsumed">Characters consumed.</param>
        string GetCandidateTicketReference(ICharIterator iterator, out int charactersConsumed)
        {
            string projectCode = String.Empty, ticketNumber = String.Empty;
            bool finishedProjectRef = false;

            charactersConsumed = 0;

            if(!IsValidBeginningOfTicketReference(iterator)) return null;

            for(var peekPosition = 1; ; peekPosition++)
            {
                var currentPeek = iterator.PeekChar(peekPosition);
                if(!currentPeek.IsAlphaNumeric()) break;

                if(!finishedProjectRef)
                {
                    if(currentPeek.IsAlpha())
                    {
                        projectCode = projectCode + currentPeek;
                        continue;
                    }

                    finishedProjectRef = true;
                }

                // If we see an alphabetic character after digits then it's not a valid ticket ref.
                // Disregard anything found so far.
                if(currentPeek.IsAlpha()) return null;

                if(!currentPeek.IsDigit()) break;

                ticketNumber = ticketNumber + currentPeek;
                charactersConsumed = peekPosition + 1;
            }

            if(String.IsNullOrEmpty(ticketNumber)) return null;

            return String.Concat(projectCode, ticketNumber);
        }

        bool IsValidBeginningOfTicketReference(ICharIterator iterator)
          => iterator.CurrentChar == BeginningCharacter;

        public TicketReferenceParser(IParsesTicketReference referenceParser)
        {
            if(referenceParser == null)
                throw new ArgumentNullException(nameof(referenceParser));
            this.referenceParser = referenceParser;
        }
    }
}
