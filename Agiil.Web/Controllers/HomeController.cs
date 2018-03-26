using System;
using System.Web.Mvc;
using Agiil.Web.Models;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class HomeController : Controller
  {
    public ActionResult Index ()
    {
      var model = new PageModel();
      return View (model);
    }
  }
}
