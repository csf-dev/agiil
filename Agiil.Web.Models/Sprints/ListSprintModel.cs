﻿using System;
using System.Collections.Generic;

namespace Agiil.Web.Models.Sprints
{
  public class ListSprintModel
  {
    public bool ShowingClosedSprints { get; set; }

    public IList<SprintSummaryDto> Sprints { get; set; }
  }
}
