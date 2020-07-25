using System;
using System.Reflection;
using Autofac;

namespace Agiil.Bootstrap.Validation
{
    public class BulkRegisterThirdPartyTypesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(GetAllThirdPartyLogicAssemblies())
                .AsSelf()
                .AsImplementedInterfaces()
                .PreserveExistingDefaults();

            builder.RegisterModule<CSF.DecoratorBuilder.DecoratorBuilderModule>();
        }

        Assembly[] GetAllThirdPartyLogicAssemblies()
        {
            return new[] {
                typeof(CSF.Configuration.IConfigurationReader).Assembly,
                typeof(CSF.Security.Authentication.IPassword).Assembly,
                typeof(CSF.Validation.StockRules.NotNullRule).Assembly,
                typeof(CSF.Configuration.IConfigurationReader).Assembly,
            };
        }
    }
}
