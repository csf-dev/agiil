using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  public interface IHasChildNodes
  {
    IList<ISearchNode> Children { get; set; }
  }
}
