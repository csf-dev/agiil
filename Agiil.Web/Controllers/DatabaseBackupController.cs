using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Data;

namespace Agiil.Web.Controllers
{
  public class DatabaseBackupController : Controller
  {
    readonly ITakesDatabaseBackup backupService;

    [HttpPost]
    public ActionResult TakeBackup()
    {
      backupService.TakeDatabaseBackup("Sample");
      return RedirectToAction(nameof(DatabaseController.Index), this.GetName<DatabaseController>());
    }

    public DatabaseBackupController(ITakesDatabaseBackup backupService)
    {
      if(backupService == null)
        throw new ArgumentNullException(nameof(backupService));

      this.backupService = backupService;
    }
  }
}
