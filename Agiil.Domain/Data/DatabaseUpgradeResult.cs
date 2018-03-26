using System;
using System.Collections.Generic;

namespace Agiil.Domain.Data
{
  public class DatabaseUpgradeResult
  {
    public bool Success { get; set; }

    public IList<IUpgradeName> UpgradesApplied { get; set; }
  }
}
