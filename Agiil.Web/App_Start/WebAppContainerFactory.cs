using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Agiil.Bootstrap;
using Autofac;
using System.Linq;
using Agiil.Web.Bootstrap;
using Autofac.Core;

namespace Agiil.Web.App_Start
{
  public class WebAppContainerFactory : DomainContainerFactory, IContainerFactoryWithHttpConfiguration
  {
    #region fields

    HttpConfiguration config;

    #endregion

    #region properties

    protected virtual HttpConfiguration HttpConfig => config;

    #endregion

    #region public API

    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = base.GetContainerBuilder();

      RegisterAspNetWebApiComponents(builder);

      RegisterAspNetMvcComponents(builder);

      return builder;
    }

    protected virtual void RegisterAspNetMvcComponents(ContainerBuilder builder)
    {
      builder.RegisterModule(new AspNetMvcModule());
    }

    protected virtual void RegisterAspNetWebApiComponents(ContainerBuilder builder)
    {
      builder.RegisterModule(new AspNetWebApiModule(HttpConfig));
    }

		protected override IEnumerable<Assembly> GetModuleAssemblies()
		{
      return base.GetModuleAssemblies().Union(new [] { Assembly.GetExecutingAssembly() });
		}

		public virtual void OverrideHttpConfiguration(HttpConfiguration config)
    {
      if(config == null)
        throw new ArgumentNullException(nameof(config));
      
      this.config = config;
    }

    #endregion

    #region constructors

    public WebAppContainerFactory()
    {
      config = new HttpConfiguration();
    }

    #endregion
  }
}
