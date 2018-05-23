using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Data;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class MissingDependenciesController : Controller
  {
    public ActionResult RequireMaintenance(AppDependencyTestResult testResult)
    {
      return View(testResult);
    }

    public ActionResult Unusable(AppDependencyTestResult testResult)
    {
      Response.StatusCode = 500;
      return View(testResult);
    }
  }
}
