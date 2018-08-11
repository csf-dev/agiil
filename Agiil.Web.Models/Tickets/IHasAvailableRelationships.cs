using System;
using System.Collections.Generic;

namespace Agiil.Web.Models.Tickets
{
  public interface IHasAvailableRelationships
  {
    IList<AvailableRelationshipDto> AvailableRelationships { get; set; }
  }
}
