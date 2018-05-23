using System;
using System.Configuration;

namespace Agiil.Web.Services.Data
{
  public class AppSettingsDatabaseMaintenanceSecurityProvider : IGetsDatabaseMaintenanceSecurity
  {
    internal const string AllowDatabaseMaintenanceKey = "AllowDatabaseMaintenance";

    public bool IsDatabaseMaintenancePermitted()
    {
      var setting = ConfigurationManager.AppSettings[AllowDatabaseMaintenanceKey];
      return String.Equals(setting, Boolean.TrueString, StringComparison.InvariantCultureIgnoreCase);
    }
  }
}
