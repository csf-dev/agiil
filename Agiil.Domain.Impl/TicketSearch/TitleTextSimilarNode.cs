using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's title must be similar to the given text, using
  /// natural text relevance matching.
  /// </summary>
  [NaturalTextOrdering]
  public class TitleTextSimilarNode : SearchNode
  {
    public string Text { get; set; }
  }
}
