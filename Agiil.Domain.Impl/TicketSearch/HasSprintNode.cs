using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket must be associated with any of the named sprints.
  /// </summary>
  public class HasSprintNode : SearchNode
  {
    ICollection<string> sprintNames;

    public ICollection<string> SprintNames
    {
      get { return sprintNames; }
      set { sprintNames = value ?? new List<string>(); }
    }
  }
}
