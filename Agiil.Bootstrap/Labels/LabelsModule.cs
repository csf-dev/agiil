using System;
using System.Collections.Generic;
using Agiil.Domain.Labels;
using Autofac;

namespace Agiil.Bootstrap.Labels
{
  public class LabelsModule : NamespaceModule
  {
    protected override string Namespace => typeof(Label).Namespace;

    protected override IEnumerable<Type> TypesNotToRegisterAutomatically
      => new [] {
        typeof(ExistingAndNewLabelProvider),
        typeof(ExistingLabelProvider),
        typeof(NewLabelProvider),
      };

		protected override void Load(ContainerBuilder builder)
		{
      base.Load(builder);
      RegisterLabelProvider(builder);
		}

    void RegisterLabelProvider(ContainerBuilder builder)
    {
      builder.RegisterType<ExistingLabelProvider>().AsSelf();
      builder.RegisterType<NewLabelProvider>().AsSelf();

      builder
        .Register(ctx => {
          var existingLabelProvider = ctx.Resolve<ExistingLabelProvider>();
          var newLabelProvider = ctx.Resolve<NewLabelProvider>();
          var nameParser = ctx.Resolve<IParsesLabelNames>();
          return new ExistingAndNewLabelProvider(existingLabelProvider, newLabelProvider, nameParser);
        })
        .As<IGetsLabels>();
    }
	}
}
