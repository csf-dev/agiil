using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Domain;
using Agiil.Domain.Data;
using Autofac;

namespace Agiil.Bootstrap.Data
{
  public class DomainDataModule : NamespaceModule
  {
    static readonly Type NamespaceMarkerType = typeof(ITakesDatabaseBackup);

    protected override string Namespace => NamespaceMarkerType.Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        NamespaceMarkerType.Assembly,
        typeof(IDomainImplementationAssemblyMarker).Assembly
      };
    }

    protected override IEnumerable<Type> TypesNotToRegisterAutomatically
    {
      get {
        return new [] {
          typeof(DataDirectoryConfigurationSection)
        };
      }
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder
        .RegisterConfiguration<DataDirectoryConfigurationSection>()
        .AsSelf()
        .As<IGetsDataDirectory>();
    }
  }
}
