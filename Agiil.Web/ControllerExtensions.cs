using System;
using System.Web.Mvc;
using Agiil.Web.App_Start;

namespace Agiil.Web
{
  internal static class ControllerExtensions
  {
    internal static string GetName(this Controller controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));

      return RouteConfiguration.GetControllerName(controller.GetType());
    }

    internal static string GetName<TOtherController>(this Controller controller)
        where TOtherController : Controller
    {
      return RouteConfiguration.GetControllerName<TOtherController>();
    }
  }
}
