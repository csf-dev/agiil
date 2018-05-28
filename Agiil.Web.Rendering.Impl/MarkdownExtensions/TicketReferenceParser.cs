using System;
using Agiil.Domain.Tickets;
using Markdig.Helpers;

namespace Agiil.Web.Rendering.MarkdownExtensions
{
  public class TicketReferenceParser
  {
    const char BeginningCharacter = '#';

    public TicketReference GetTicketReference(ICharIterator iterator, out int charactersConsumed)
    {
      string projectCode = String.Empty, ticketNumber = String.Empty;
      bool finishedProjectRef = false;

      charactersConsumed = 0;

      if(!IsValidBeginningOfTicketReference(iterator)) return null;

      for(var peekPosition = 1;;peekPosition++)
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
        // Disregard any digits seen so far and break out of the loop.
        if(currentPeek.IsAlpha())
        {
          ticketNumber = String.Empty;
          break;
        }

        if(!currentPeek.IsDigit()) break;

        ticketNumber = ticketNumber + currentPeek;
        charactersConsumed = peekPosition + 1;
      }

      var ticketRef = GetTicketReference(projectCode, ticketNumber);
      if(ticketRef == null) charactersConsumed = 0;
      return ticketRef;
    }

    TicketReference GetTicketReference(string projectCode, string ticketNumber)
    {
      if(String.IsNullOrEmpty(ticketNumber)) return null;
      
      var projectCodeOrNull = String.IsNullOrEmpty(projectCode)? null : projectCode;
      var parsedTicketNumber = Int64.Parse(ticketNumber);

      return new TicketReference(projectCodeOrNull, parsedTicketNumber);
    }

    bool IsValidBeginningOfTicketReference(ICharIterator iterator)
      => iterator.CurrentChar == BeginningCharacter;
  }
}
