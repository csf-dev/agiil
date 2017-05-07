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
  public class DatabaseController : ControllerBase
  {
    const string TempModelKey = "Reset model";

    readonly Func<ISession> session;
    readonly Func<IDatabaseCreator> creator;
    readonly Func<IInitialDataCreator> dataCreator;

    [HttpGet]
    public ActionResult Index()
    {
      var model = base.GetTempData<DatabaseResetModel>(TempModelKey);
      model = model?? new DatabaseResetModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult Reset()
    {
      creator().Create(session().Connection, null);
      dataCreator().Create();

      var model = new DatabaseResetModel { HasBeenReset = true };
      TempData.Add(TempModelKey, model);
      return RedirectToAction(nameof(Index));
    }

    public DatabaseController(Func<ISession> session,
                              Func<IDatabaseCreator> creator,
                              Func<IInitialDataCreator> dataCreator)
    {
      if(dataCreator == null)
        throw new ArgumentNullException(nameof(dataCreator));
      if(creator == null)
        throw new ArgumentNullException(nameof(creator));
      if(session == null)
        throw new ArgumentNullException(nameof(session));

      this.session = session;
      this.creator = creator;
      this.dataCreator = dataCreator;;
    }
  }
}
