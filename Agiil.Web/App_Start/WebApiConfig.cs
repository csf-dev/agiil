using System.Web.Http;

namespace Agiil.Web.App_Start
{
  public class WebApiConfig
  {
    public void Register (HttpConfiguration config)
    {
      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes ();

      config.Routes.MapHttpRoute (
        name: "DefaultApi",
        routeTemplate: "api/v1/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
