using System;
using System.Linq;
using System.Web.Mvc;
using Agiil.Data.Maintenance;
using Agiil.Web.Models;

namespace Agiil.Web.Controllers
{
  public class DatabaseController : ControllerBase
  {
    const string TempModelKey = "Reset model";

    readonly Lazy<IDatabaseResetter> resetter;
    readonly Lazy<IDatabaseUpgrader> upgrader;

    [HttpGet]
    public ActionResult Index()
    {
      var model = base.GetTempData<DatabaseResetModel>(TempModelKey);
      model = model?? GetModel();
      model.DatabaseUpgradesApplied = upgrader.Value.GetAppliedUpgrades().Select(x => x.GetName());
      model.DatabaseUpgradesPending = upgrader.Value.GetPendingUpgrades().Select(x => x.GetName());
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

    public DatabaseController(Lazy<IDatabaseResetter> resetter,
                              Lazy<IDatabaseUpgrader> upgrader,
                              ControllerBaseDependencies baseDeps)
      : base(baseDeps)
    {
      if(upgrader == null)
        throw new ArgumentNullException(nameof(upgrader));
      if(resetter == null)
        throw new ArgumentNullException(nameof(resetter));

      this.resetter = resetter;
      this.upgrader = upgrader;
    }
  }
}
