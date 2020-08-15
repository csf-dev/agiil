using System;
using System.Reflection;
using Autofac;

namespace Agiil.Bootstrap.Validation
{
    public class BulkRegisterThirdPartyTypesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = GetAllThirdPartyLogicAssemblies();

            builder
                .RegisterAssemblyTypes(assemblies)
                .AsSelf()
                .AsImplementedInterfaces()
                .PreserveExistingDefaults();

            builder.RegisterModule<CSF.DecoratorBuilder.DecoratorBuilderModule>();

            builder.BulkRegisterAllOpenGenericTypesInAssemblies(assemblies);
        }

        Assembly[] GetAllThirdPartyLogicAssemblies()
        {
            return new[] {
                typeof(CSF.Configuration.IConfigurationReader).Assembly,
                typeof(CSF.Security.Authentication.IPassword).Assembly,
                typeof(CSF.Validation.StockRules.NotNullRule).Assembly,
                typeof(CSF.Configuration.IConfigurationReader).Assembly,
                typeof(CSF.Validation.Validator).Assembly,
            };
        }
    }
}
