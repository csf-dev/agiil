﻿using System;
using Autofac;
using CSF.Data;

namespace Agiil.Tests.Bootstrap
{
  public class BusinessTransactionModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<NoOpTransactionCreator>()
        .As<ITransactionCreator>();
    }
  }
}