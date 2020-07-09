using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Data;
using Agiil.Data.Sqlite;
using Agiil.Domain.Data;
using Autofac;
using Autofac.Core;
using CSF.DecoratorBuilder;

namespace Agiil.Bootstrap.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
              .RegisterType<SnapshotStore>()
              .SingleInstance();

            builder.RegisterDecoratedService<IPerformsDatabaseUpgrades>(d => d
                .UsingInitialImpl<DbUpDatabaseUpgrader>()
                .ThenWrapWith<BackupTakingUpgrader>());

            builder
              .RegisterConfiguration<DataDirectoryConfigurationSection>()
              .AsSelf()
              .As<IGetsDataDirectory>();

            builder.Register(GetConnectionStringAdapter);
        }

        IGetsDatabaseFilePath GetConnectionStringAdapter(IComponentContext ctx, IEnumerable<Parameter> @params)
        {
            var connectionStringParam = @params
                .OfType<TypedParameter>()
                .FirstOrDefault(x => x.Type == typeof(string));

            if(connectionStringParam != null)
                return ctx.Resolve<ConnectionStringAdapter>(connectionStringParam);

            if(@params.OfType<TypedParameter>().FirstOrDefault(x => x.Type == typeof(IConnectionStringProvider))?.Value is IConnectionStringProvider provider)
                return ctx.Resolve<ConnectionStringAdapter>(TypedParameter.From(provider.GetConnectionString()));

            throw new DependencyResolutionException($"Cannot resolve an instance of {nameof(IGetsDatabaseFilePath)}, either a {nameof(String)} or a {nameof(IConnectionStringProvider)} parameter must be provided.");
        }
    }
}
