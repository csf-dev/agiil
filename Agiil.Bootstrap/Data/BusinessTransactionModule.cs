using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using NHibernate;
using CSF.Data;
using CSF.Data.NHibernate;

namespace Agiil.Bootstrap.Data
{
  public class BusinessTransactionModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<TransactionCreator>()
        .As<ITransactionCreator>();
    }
  }
}
