using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's description must contain the given text, verbatim.
  /// </summary>
  public class DescriptionTextContainsNode : SearchNode
  {
    public string Text { get; set; }
  }
}
