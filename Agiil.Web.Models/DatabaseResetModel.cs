using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class DatabaseResetModel
  {
    public bool HasBeenReset { get; set; }

    public bool UpgradesAttempted => UpgradesSuccessful.HasValue;

    public bool? UpgradesSuccessful { get; set; }

    public bool UpgradeSuccess => UpgradesSuccessful.GetValueOrDefault();

    public bool HasPendingUpgrades => DatabaseUpgradesPending != null && DatabaseUpgradesPending.Any();

    public IEnumerable<string> DatabaseUpgradesApplied { get; set; }

    public IEnumerable<string> DatabaseUpgradesPending { get; set; }
  }
}
