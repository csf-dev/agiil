using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket must be associated with any of the named labels.
  /// </summary>
  public class HasLabelNode : SearchNode
  {
    ICollection<string> labelNames;

    public ICollection<string> LabelNames
    {
      get { return labelNames; }
      set { labelNames = value ?? new List<string>(); }
    }
  }
}
