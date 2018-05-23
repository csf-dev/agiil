using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Data;
using Agiil.Web.Services.Data;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class DatabaseBackupController : Controller
  {
    readonly IGetsDatabaseMaintenanceSecurity securityProvider;
    readonly ITakesDatabaseBackup backupService;
    readonly IRestoresDatabaseBackup backupRestorer;

    [HttpPost]
    public ActionResult TakeBackup(string name)
    {
      if(!securityProvider.IsDatabaseMaintenancePermitted())
        return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

      backupService.TakeDatabaseBackup(name);
      return RedirectToAction(nameof(DatabaseController.Index), this.GetName<DatabaseController>());
    }

    [HttpGet]
    public ActionResult Index(string filename)
    {
      if(!securityProvider.IsDatabaseMaintenancePermitted())
        return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

      return View((object) filename);
    }

    [HttpPost]
    public ActionResult ConfirmRestoreBackup(string filename)
    {
      if(!securityProvider.IsDatabaseMaintenancePermitted())
        return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

      backupRestorer.RestoreDatabaseBackup(filename);
      return RedirectToAction(nameof(DatabaseController.Index), this.GetName<DatabaseController>());
    }

    public DatabaseBackupController(ITakesDatabaseBackup backupService,
                                    IRestoresDatabaseBackup backupRestorer,
                                    IGetsDatabaseMaintenanceSecurity securityProvider)
    {
      if(securityProvider == null)
        throw new ArgumentNullException(nameof(securityProvider));
      if(backupRestorer == null)
        throw new ArgumentNullException(nameof(backupRestorer));
      if(backupService == null)
        throw new ArgumentNullException(nameof(backupService));

      this.backupRestorer = backupRestorer;
      this.securityProvider = securityProvider;
      this.backupService = backupService;
    }
  }
}
