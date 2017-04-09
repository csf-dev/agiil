using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Data;
using Agiil.Domain.Data;
using Autofac;
using Autofac.Core;
using NHibernate;

namespace Agiil.Bootstrap.Data
{
  public class BusinessTransactionModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .Register(CreateTransaction)
        .As<INestableTransaction>();

      builder
        .RegisterType<CurrentTransactionReader>()
        .As<ICurrentTransactionReader>();

      builder
        .RegisterType<TransactionFactory>()
        .As<ITransactionFactory>();

      builder
        .RegisterType<OwnedTransactionWrapper>()
        .InstancePerMatchingLifetimeScope(new TypedService(typeof(INestableTransaction)));
    }

    NestableTransaction CreateTransaction(IComponentContext ctx, IEnumerable<Parameter> parameters)
    {
      var nhibernateTransaction = parameters
        .Where(x => x is TypedParameter)
        .Cast<TypedParameter>()
        .Where(x => x.Type == typeof(ITransaction))
        .Select(x => x.Value)
        .Cast<ITransaction>()
        .FirstOrDefault();

      if(nhibernateTransaction != null)
      {
        return new NestableTransaction(nhibernateTransaction);
      }

      return new NestableTransaction();
    }
  }
}
