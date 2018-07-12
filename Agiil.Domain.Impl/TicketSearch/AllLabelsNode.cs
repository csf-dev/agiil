using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket must be associated with all of the named labels.
  /// </summary>
  public class AllLabelsNode : SearchNode
  {
    ICollection<string> labelNames;

    public ICollection<string> LabelNames
    {
      get { return labelNames; }
      set { labelNames = value ?? new List<string>(); }
    }
  }
}
