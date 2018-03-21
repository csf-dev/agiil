using System;
using System.Collections.Generic;

namespace Agiil.Domain.Data
{
  public interface IPerformsDatabaseUpgrades
  {
    IList<IUpgradeName> GetAppliedUpgrades();

    IList<IUpgradeName> GetPendingUpgrades();

    DatabaseUpgradeResult ApplyAllUpgrades();
  }
}
