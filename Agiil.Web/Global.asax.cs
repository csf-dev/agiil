using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Agiil.Web.App_Start;

namespace Agiil.Web
{
  public class Global : HttpApplication
  {
    protected void Application_Start ()
    {
      AreaRegistration.RegisterAllAreas ();
    }
  }
}
