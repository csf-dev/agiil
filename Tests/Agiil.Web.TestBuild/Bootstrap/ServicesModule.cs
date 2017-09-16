using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Bootstrap;
using Agiil.Web.Services;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class ServicesModule : NamespaceModule
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      RegisterLoginReader(builder);
    }

    protected override string Namespace
      => typeof(IServicesNamespaceMarker).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
      => new [] { Assembly.GetExecutingAssembly() };

    protected override IEnumerable<Type> TypesNotToRegisterAutomatically
    {
      get {
        return new [] {
          typeof(OverridableLoginReader),
        };
      }
    }

    void RegisterLoginReader(ContainerBuilder builder)
    {
      builder
        .RegisterType<OverridableLoginReader>()
        .AsSelf()
        .AsImplementedInterfaces()
        .InstancePerRequest();
    }
  }
}
