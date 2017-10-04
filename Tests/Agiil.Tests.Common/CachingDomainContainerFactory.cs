using System;
using Agiil.Bootstrap;
using Autofac;

namespace Agiil.Tests
{
  public class CachingDomainContainerFactory : DomainContainerFactory
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

    public CachingDomainContainerFactory()
    {
      syncRoot = new object();
    }

    static CachingDomainContainerFactory()
    {
      defaultInstance = new CachingDomainContainerFactory();
    }

    public static IAutofacContainerFactory Default => defaultInstance;
  }
}
