using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace Agiil.Web
{
  public class Global : HttpApplication
  {
    protected void Application_Start ()
    {
      AreaRegistration.RegisterAllAreas ();

      GlobalConfiguration.Configure (App_Start.WebApiConfig.Register);
      App_Start.RouteConfig.RegisterRoutes (RouteTable.Routes);

      App_Start.ViewConfig.RegisterViewEngines(ViewEngines.Engines);
    }
  }
}
