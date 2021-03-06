﻿using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Agiil.Bootstrap.DiConfiguration;
using Agiil.Web.Bootstrap;
using Agiil.Web.OAuth;
using Agiil.Web.App_Start;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Owin.Security.AesDataProtectorProvider;

[assembly: OwinStartup(typeof(OwinStartupType), nameof(OwinStartupType.Configuration))]

namespace Agiil.Web.App_Start
{
  /// <summary>
  /// Implementation of an OWIN startup configuration type.  Must be named <c>Startup</c> and must have a
  /// <c>Configuration</c> method.
  /// </summary>
  public class OwinStartupType
  {
    public void Configuration(IAppBuilder app)
    {
      var logger = log4net.LogManager.GetLogger(typeof(OwinStartupType));
      logger.Info($"The Agiil OWIN application is starting up");

      var config = new HttpConfiguration();

      var container = ConfigureDependencyInjection(app, config);

      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

      ConfigureOAuthServer(app, container);
      ConfigureWebApi(app, container, config);
      ConfigureWebApp(app, container);

      config.EnsureInitialized();
    }

    void ConfigureOAuthServer(IAppBuilder app, IContainer container)
    {
      app.MapWhen(IsOAuthUrl, inner => {
        var authServerOptions = container.Resolve<OAuthAuthorizationServerOptions>();
        inner.UseOAuthAuthorizationServer(authServerOptions);
      });
    }

    void ConfigureWebApi(IAppBuilder app, IContainer container, HttpConfiguration config)
    {
      app.MapWhen(IsWebApiUrl, inner => {
        ConfigureWebApiAuthentication(inner, container);

        config.Filters.Add(new HostAuthenticationFilter(DefaultAuthenticationTypes.ApplicationCookie));

        config.Routes.Clear();
        new RouteConfiguration().RegisterWebApiRoutes(config);
        new WebApiModelBindingRules().Apply(config);
        new WebApiFilterConfiguration().RegisterFilters(config);
        inner.UseAutofacWebApi(config);
        inner.UseWebApi(config);
      });
    }

    void ConfigureWebApp(IAppBuilder app, IContainer container)
    {
      app.MapWhen(IsWebAppUrl, inner => {
        new RouteConfiguration().RegisterMvcRoutes (RouteTable.Routes);
        new MvcViewConfiguration().RegisterViewEngines(ViewEngines.Engines);
        ConfigureCookieAuthentication(inner);
        inner.UseAutofacMvc();
      });
    }

    bool IsOAuthUrl(IOwinContext context)
    {
      if(context.Request.Uri.LocalPath.StartsWith(RouteConfiguration.OAuthPrefix, StringComparison.InvariantCulture))
        return true;

      return false;
    }

    bool IsWebApiUrl(IOwinContext context)
    {
      if(context.Request.Uri.LocalPath.StartsWith("/" + RouteConfiguration.ApiPrefix, StringComparison.InvariantCulture))
        return true;
      
      return false;
    }

    bool IsWebAppUrl(IOwinContext context)
    {
      return !(IsOAuthUrl(context) || IsWebApiUrl(context));
    }

    IContainer ConfigureDependencyInjection(IAppBuilder app, HttpConfiguration config)
    {
      var factoryProvider = new ContainerFactoryProvider();
      var container = factoryProvider.GetContainer(config);

      var lifetimeScopeProvider = new OwinCompatibleLifetimeScopeProvider(container);

      DependencyResolver.SetResolver(new AutofacDependencyResolver(container, lifetimeScopeProvider));

      return container;
    }

    void ConfigureCookieAuthentication(IAppBuilder builder)
    {
      builder.UseCookieAuthentication(new CookieAuthenticationOptions {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString(RouteConfiguration.GetMvcLoginPath()),
        ReturnUrlParameter = "returnUrl",
      });

      builder.UseAesDataProtectorProvider();
    }

    void ConfigureWebApiAuthentication(IAppBuilder builder, IContainer container)
    {
      builder.UseCookieAuthentication(new CookieAuthenticationOptions {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
      });

      builder.UseAesDataProtectorProvider();
    }
  }
}
