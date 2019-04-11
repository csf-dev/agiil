using System;
using System.Text.RegularExpressions;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceParser : IParsesTicketReference
  {
    const RegexOptions ReferenceMatchOptions = RegexOptions.Compiled
                                               | RegexOptions.CultureInvariant
                                               | RegexOptions.IgnoreCase;
    const string ReferencePattern = @"^#?([A-Z]+)?(\d+)$";
    static readonly Regex ReferenceMatcher = new Regex(ReferencePattern, ReferenceMatchOptions);

    public TicketReference GetReference(IIdentifiesTicketByProjectAndNumber ticket)
    {
      if(ticket == null)
        return null;

      return GetReference(ticket.ProjectCode, ticket.TicketNumber);
    }

    public TicketReference GetReference(string projectCode, long ticketNumber)
    {
      var code = projectCode ?? String.Empty;
      var output = String.Concat(code, ticketNumber.ToString());

      if(!ReferenceMatcher.IsMatch(output))
        return null;

      return new TicketReference(code, ticketNumber);
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
