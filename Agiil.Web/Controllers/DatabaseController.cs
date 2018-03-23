using System;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Data;
using Agiil.Web.Models;

namespace Agiil.Web.Controllers
{
  public class DatabaseController : Controller
  {
    const string TempModelKey = "Reset model";

    readonly Lazy<IResetsDatabase> resetter;
    readonly Lazy<IPerformsDatabaseUpgrades> upgrader;
    readonly Lazy<IGetsDatabaseBackups> backupFinder;

    [HttpGet]
    public ActionResult Index()
    {
      var model = TempData.TryGet<DatabaseResetModel>(TempModelKey);
      model = model?? GetModel();
      model.DatabaseUpgradesApplied = upgrader.Value.GetAppliedUpgrades().Select(x => x.GetName());
      model.DatabaseUpgradesPending = upgrader.Value.GetPendingUpgrades().Select(x => x.GetName());
      model.DatabaseBackups = backupFinder.Value.GetBackups();
      return View(model);
    }

    [HttpPost]
    public ActionResult Reset()
    {
      TempData.Clear();
      resetter.Value.ResetDatabase();
      var model = GetModel();
      model.HasBeenReset = true;
      TempData.Add(TempModelKey, model);
      return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public ActionResult Upgrade()
    {
      TempData.Clear();
      var result = upgrader.Value.ApplyAllUpgrades();
      var model = GetModel();
      model.UpgradesSuccessful = result.Success;
      TempData.Add(TempModelKey, model);
      return RedirectToAction(nameof(Index));
    }

    DatabaseResetModel GetModel()
    {
      return new DatabaseResetModel();
    }

    public DatabaseController(Lazy<IResetsDatabase> resetter,
                              Lazy<IPerformsDatabaseUpgrades> upgrader,
                              Lazy<IGetsDatabaseBackups> backupFinder)
    {
      if(backupFinder == null)
        throw new ArgumentNullException(nameof(backupFinder));
      if(upgrader == null)
        throw new ArgumentNullException(nameof(upgrader));
      if(resetter == null)
        throw new ArgumentNullException(nameof(resetter));

      this.backupFinder = backupFinder;
      this.resetter = resetter;
      this.upgrader = upgrader;
    }
  }
}
