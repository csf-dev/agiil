using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Agiil.Web.App_Start.Startup))]

namespace Agiil.Web.App_Start
{
  /// <summary>
  /// Implementation of an OWIN startup configuration type.  Must be named <c>Startup</c> and must have a
  /// <c>Configuration</c> method.
  /// </summary>
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      new OwinDependencyInjectionConfig().Configure(app);
      new AuthConfig().Configure(app);
    }
  }
}
