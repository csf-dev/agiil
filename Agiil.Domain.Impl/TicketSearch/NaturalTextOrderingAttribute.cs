using System;
namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// Indicates that a criteria search node may provide relevance-based ordering based upon a
  /// "natural text" search.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public class NaturalTextOrderingAttribute : Attribute
  {
  }
}
