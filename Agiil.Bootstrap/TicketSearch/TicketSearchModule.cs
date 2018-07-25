using System;
using System.Collections.Generic;
using Agiil.Domain.TicketSearch;
using Autofac;

namespace Agiil.Bootstrap.TicketSearch
{
  public class TicketSearchModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder.RegisterType<ConstantValueResolver>().AsImplementedInterfaces();
      builder.RegisterType<SpecificationBuildingSearchVisitor>().AsSelf().As<IVisitsTicketSearch>();
      builder.RegisterType<StrategyBasedCriterionToSpecificationConverter>().AsImplementedInterfaces();
      builder.RegisterType<VisitorBasedSpecificationProvider>().AsImplementedInterfaces();

      base.Load(builder);

		}
	}
}
