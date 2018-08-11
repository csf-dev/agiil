using System;
using System.Collections.Generic;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Models.Tickets
{
  public interface IHasAvailableSprints
  {
    IList<SprintSummaryDto> AvailableSprints { get; set; }
  }
}
