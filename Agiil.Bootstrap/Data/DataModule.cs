﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Configuration;
using Agiil.Data;
using Agiil.Domain.Data;
using Autofac;
using Agiil.Domain;

namespace Agiil.Bootstrap.Data
{
  public class DataModule : NamespaceModule
  {
    static readonly Type NamespaceMarkerType = typeof(ISnapshotService);

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
          typeof(SnapshotStore),
          typeof(SnapshottingDatabaseResetter),
          typeof(NHibernateSchemaExportingDatabaseCreator),
        };
      }
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder
        .RegisterType<SnapshotStore>()
        .SingleInstance();

      builder
        .RegisterType<SnapshottingDatabaseResetter>()
        .AsSelf();

      builder
        .RegisterType<NHibernateSchemaExportingDatabaseCreator>()
        .AsSelf()
        .As<IExportsDatabaseSchema>();
    }
  }
}
