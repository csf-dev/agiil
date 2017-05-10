using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Data;
using Agiil.Domain.Data;
using Agiil.Web.Models;
using NHibernate;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class DatabaseController : ControllerBase
  {
    const string TempModelKey = "Reset model";

    readonly Lazy<IDatabaseResetter> resetter;

    [HttpGet]
    public ActionResult Index()
    {
      var model = base.GetTempData<DatabaseResetModel>(TempModelKey);
      model = model?? GetModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult Reset()
    {
      resetter.Value.ResetDatabase();
      var model = GetModel(true);
      TempData.Add(TempModelKey, model);
      return RedirectToAction(nameof(Index));
    }

    DatabaseResetModel GetModel(bool hasBeenReset = false)
    {
      var model = ModelFactory.GetModel<DatabaseResetModel>();
      model.HasBeenReset = hasBeenReset;
      return model;
    }

    public DatabaseController(Lazy<IDatabaseResetter> resetter,
                              Services.SharedModel.StandardPageModelFactory modelFactory)
      : base(modelFactory)
    {
      if(resetter == null)
        throw new ArgumentNullException(nameof(resetter));

      this.resetter = resetter;
    }
  }
}
