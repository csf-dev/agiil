using System;
namespace Agiil.Web.Services.Data
{
  public interface IGetsDatabaseMaintenanceSecurity
  {
    bool IsDatabaseMaintenancePermitted();
  }
}
