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
    readonly IRestoresDatabaseBackup backupRestorer;

    [HttpPost]
    public ActionResult TakeBackup(string name)
    {
      backupService.TakeDatabaseBackup(name);
      return RedirectToAction(nameof(DatabaseController.Index), this.GetName<DatabaseController>());
    }

    [HttpGet]
    public ActionResult Index(string filename)
    {
      return View((object) filename);
    }

    [HttpPost]
    public ActionResult ConfirmRestoreBackup(string filename)
    {
      backupRestorer.RestoreDatabaseBackup(filename);
      return RedirectToAction(nameof(DatabaseController.Index), this.GetName<DatabaseController>());
    }

    public DatabaseBackupController(ITakesDatabaseBackup backupService,
                                    IRestoresDatabaseBackup backupRestorer)
    {
      if(backupRestorer == null)
        throw new ArgumentNullException(nameof(backupRestorer));
      if(backupService == null)
        throw new ArgumentNullException(nameof(backupService));

      this.backupRestorer = backupRestorer;
      this.backupService = backupService;
    }
  }
}
