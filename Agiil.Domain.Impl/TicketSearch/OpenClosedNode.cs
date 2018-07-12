using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node which filters upon the open/closed state of the ticket.
  /// </summary>
  public class OpenClosedNode : SearchNode
  {
    public bool AcceptOpen { get; set; }

    public bool AcceptClosed { get; set; }
  }
}
