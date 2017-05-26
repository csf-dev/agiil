using System;
using System.Web.Mvc;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class HomeController : ControllerBase
  {
    public ActionResult Index ()
    {
      var model = ModelFactory.GetModel<StandardPageModel>();
      return View (model);
    }

    public HomeController(ControllerBaseDependencies baseDeps)
      : base(baseDeps)
    {}
  }
}
