using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's title must contain the given text, verbatim.
  /// </summary>
  public class TitleTextContainsNode : SearchNode
  {
    public string Text { get; set; }
  }
}
