using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that at least one of the ticket's comments must contain the given text, verbatim.
  /// </summary>
  public class CommentTextContainsNode : SearchNode
  {
    public string Text { get; set; }
  }
}
