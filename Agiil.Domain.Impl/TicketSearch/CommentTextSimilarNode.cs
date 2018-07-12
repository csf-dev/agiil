using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's description must be similar to the given text, using
  /// natural text relevance matching.
  /// </summary>
  [NaturalTextOrdering]
  public class CommentTextSimilarNode : SearchNode
  {
    public string Text { get; set; }
  }
}
