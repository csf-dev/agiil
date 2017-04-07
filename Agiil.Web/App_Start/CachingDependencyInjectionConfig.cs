using System;
using System.Web.Http;
using Autofac;

namespace Agiil.Web.App_Start
{
  public class CachingDependencyInjectionConfig : DependencyInjectionConfig
  {
    #region fields

    readonly object syncRoot;
    IContainer container;

    #endregion

    #region overrides

    public override IContainer GetDependencyInjectionContainer(HttpConfiguration config)
    {
      lock(syncRoot)
      {
        if(container == null)
        {
          container = base.GetDependencyInjectionContainer(config);
        }

        return container;
      }
    }

    #endregion

    #region constructor

    public CachingDependencyInjectionConfig()
    {
      syncRoot = new object();
    }

    #endregion
  }
}
