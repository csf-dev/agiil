using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's type must be one of the named types.
  /// </summary>
  public class IsTicketTypeNode : SearchNode
  {
    ICollection<string> typeNames;

    public ICollection<string> TypeNames
    {
      get { return typeNames; }
      set { typeNames = value ?? new List<string>(); }
    }
  }
}
