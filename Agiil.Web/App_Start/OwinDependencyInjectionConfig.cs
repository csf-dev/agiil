using System;
using System.Web.Http;
using Owin;

namespace Agiil.Web.App_Start
{
  public class OwinDependencyInjectionConfig
  {
    public void Configure(IAppBuilder builder)
    {
      var config = new HttpConfiguration();

      var container = DependencyInjectionConfig.GetDependencyInjectionContainer();
      builder.UseAutofacMiddleware(container);

      builder.UseAutofacMvc();

      builder.UseAutofacWebApi(config);
      builder.UseWebApi(config);
    }
  }
}
