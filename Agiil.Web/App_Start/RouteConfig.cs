using System.Web.Mvc;
using System.Web.Routing;

namespace Agiil.Web.App_Start
{
  public class RouteConfig
  {
    public void RegisterRoutes (RouteCollection routes)
    {
      routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
      routes.IgnoreRoute ("oauth2/{*action}");

      routes.MapMvcAttributeRoutes();

      routes.MapRoute (
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
