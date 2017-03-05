﻿using System;
using Autofac;
using CSF.Data;

namespace Agiil.BDD.Bootstrap
{
  public class QueryModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<InMemoryQuery>()
        .AsSelf()
        .As<IQuery>()
        .InstancePerLifetimeScope();
    }
  }
}
