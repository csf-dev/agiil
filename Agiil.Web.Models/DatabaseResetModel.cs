using System;
using System.Collections.Generic;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class DatabaseResetModel
  {
    public bool HasBeenReset { get; set; }

    public bool? UpgradesSuccessful { get; set; }

    public IEnumerable<string> DatabaseUpgradesApplied { get; set; }

    public IEnumerable<string> DatabaseUpgradesPending { get; set; }
  }
}
