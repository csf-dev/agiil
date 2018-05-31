using System;
using Agiil.Bootstrap;
using Agiil.Web.App_Start;
using Autofac;

namespace Agiil.Tests.Web
{
  public class CachingWebAppContainerFactory : WebAppContainerFactory
  {
    static readonly IAutofacContainerFactory defaultInstance;

    readonly object syncRoot;
    IContainer container;

    public override IContainer GetContainer()
    {
      lock(syncRoot)
      {
        if(container == null)
          container = base.GetContainer();
      }

      return container;
    }

    public CachingWebAppContainerFactory()
    {
      syncRoot = new object();
    }

    static CachingWebAppContainerFactory()
    {
      defaultInstance = new CachingWebAppContainerFactory();
    }

    public static IAutofacContainerFactory Default => defaultInstance;
  }
}
