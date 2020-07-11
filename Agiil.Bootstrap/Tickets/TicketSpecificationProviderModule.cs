using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.TicketSearch;
using Autofac;
using CSF.DecoratorBuilder;

namespace Agiil.Bootstrap.Tickets
{
    public class TicketSpecificationProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDecoratedService<IGetsTicketSpecification>((d, p) => d
                .UsingInitialImpl<VisitorBasedSpecificationProvider>(p)
                .ThenWrapWith<CurrentProjectCriterionAddingSpecProviderDecorator>(p));
        }


    }
}
