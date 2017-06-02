﻿using System;
using System.Text.RegularExpressions;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceParser : ITicketReferenceParser
  {
    const RegexOptions ReferenceMatchOptions = RegexOptions.Compiled
                                               | RegexOptions.CultureInvariant
                                               | RegexOptions.IgnoreCase;
    const string ReferencePattern = @"^([A-Z]+)(\d+)$";
    static readonly Regex ReferenceMatcher = new Regex(ReferencePattern, ReferenceMatchOptions);

    public string CreateReference(TicketReference reference)
    {
      if(reference == null)
        return null;

      return CreateReference(reference.ProjectCode, reference.TicketNumber);
    }

    public string CreateReference(string projectCode, long ticketNumber)
    {
      if(projectCode == null)
        return null;
      
      var output = String.Concat(projectCode, ticketNumber.ToString());

      if(!ReferenceMatcher.IsMatch(output))
        return null;

      return output;
    }

    public string CreateReference(Ticket ticket)
    {
      if(ticket == null)
        return null;
      
      return CreateReference(ticket.Project?.Code, ticket.TicketNumber);
    }

    public TicketReference ParseReferece(string reference)
    {
      if(reference == null)
        return null;

      var match = ReferenceMatcher.Match(reference);
      if(!match.Success)
        return null;

      return new TicketReference(match.Groups[1].Value, Int64.Parse(match.Groups[2].Value));
    }
  }
}
