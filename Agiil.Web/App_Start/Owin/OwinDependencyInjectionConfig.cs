using System;
using System.Web.Http;
using System.Web.Mvc;
using Agiil.Web.Bootstrap;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Agiil.Web.App_Start.Owin
{
  public class OwinDependencyInjectionConfig
  {
    public void Configure(IAppBuilder builder, HttpConfiguration config)
    {
      var container = new CachingDependencyInjectionConfig().GetDependencyInjectionContainer(config);

      var hackedProvider = new OwinCompatibleLifetimeScopeProvider(container);

      DependencyResolver.SetResolver(new AutofacDependencyResolver(container,hackedProvider));
      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
  }
}
