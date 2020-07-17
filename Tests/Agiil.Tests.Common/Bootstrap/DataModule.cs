using System;
using Autofac;
using Agiil.Domain.Data;
using Agiil.Tests.Data;
using Agiil.Data;
using CSF.DecoratorBuilder;

namespace Agiil.Tests.Bootstrap
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
              .RegisterType<TestingDatabaseConfiguration>()
              .As<IDatabaseConfiguration>();
        }
    }
}
