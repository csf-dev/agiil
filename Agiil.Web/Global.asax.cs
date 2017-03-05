using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Agiil.Web
{
  public class Global : HttpApplication
  {
    protected void Application_Start ()
    {
      AreaRegistration.RegisterAllAreas ();

      ConfigureWebApiApplication();
      ConfigureMvcApplication();
      ConfigureDependencyInjection();
    }

    private void ConfigureMvcApplication()
    {
      App_Start.RouteConfig.RegisterRoutes (RouteTable.Routes);
      App_Start.ViewConfig.RegisterViewEngines(ViewEngines.Engines);
    }

    private void ConfigureWebApiApplication()
    {
      GlobalConfiguration.Configure (App_Start.WebApiConfig.Register);
    }

    private void ConfigureDependencyInjection()
    {
      var container = App_Start.DependencyInjectionConfig.GetDependencyInjectionContainer();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

      GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
  }
}
