using System;
using Agiil.Domain.Tickets;
using Markdig.Helpers;

namespace Agiil.Web.Rendering.MarkdownExtensions
{
    public interface IParsesTicketReferenceFromMarkdigCharIterator
    {
        TicketReference GetTicketReference(ICharIterator iterator, out int charactersConsumed);
    }
}
