using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's full text (an aggregate of the text of the ticket)
  /// must be similar to the given text, using natural text relevance matching.
  /// </summary>
  [NaturalTextOrdering]
  public class FulltextSimilarNode : SearchNode
  {
    public string Text { get; set; }
  }
}
