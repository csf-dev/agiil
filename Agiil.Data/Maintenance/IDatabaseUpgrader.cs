using System;
using System.Collections.Generic;

namespace Agiil.Data.Maintenance
{
  public interface IDatabaseUpgrader
  {
    IList<IUpgradeName> GetAppliedUpgrades();

    IList<IUpgradeName> GetPendingUpgrades();

    DatabaseUpgradeResult ApplyAllUpgrades();
  }
}
