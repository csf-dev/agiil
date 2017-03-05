using Agiil.Web.App_Start;
using Owin;

namespace Agiil.Web
{
  /// <summary>
  /// Implementation of an OWIN startup configuration type.  Must be named <c>Startup</c> and must have a
  /// <c>Configuration</c> method.
  /// </summary>
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      new AuthConfig().Configure(app);
    }
  }
}
