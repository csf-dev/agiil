using System;
using System.Web.Mvc;
using Agiil.Web.App_Start;

namespace Agiil.Web
{
  public static class ControllerExtensions
  {
    public static string GetName(this Controller controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));

      return RouteConfiguration.GetControllerName(controller.GetType());
    }

    public static string GetName<TOtherController>(this Controller controller)
        where TOtherController : Controller
    {
      return RouteConfiguration.GetControllerName<TOtherController>();
    }

    public static string AsControllerName(this Type controllerType)
    {
      return RouteConfiguration.GetControllerName(controllerType);
    }
  }
}
