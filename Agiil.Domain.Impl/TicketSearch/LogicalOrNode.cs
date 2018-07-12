using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// Indicates that ANY of the <see cref="IHasChildNodes.Children"/> of the current node must be true in order to
  /// consider this criterion satisfied.
  /// </summary>
  public class LogicalOrNode : SearchNode
  {
  }
}
