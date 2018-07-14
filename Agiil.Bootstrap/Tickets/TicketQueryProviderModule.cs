using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Tickets;
using Autofac;
using Autofac.Core;
using CSF.Data.Specifications;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketQueryProviderModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder.RegisterType<TicketQueryProvider>();
      builder.RegisterType<SpecificationQueryProviderDecorator>();

      builder.Register(GetTicketQuery);
		}

    IGetsQueryForTickets GetTicketQuery(IComponentContext context, IEnumerable<Parameter> autofacParams)
    {
      var baseProvider = context.Resolve<TicketQueryProvider>();
      var specification = GetSpecification(autofacParams);
      
      if(specification == null)
        return baseProvider;
        
      var decoratedParam = new TypedParameter(typeof(IGetsQueryForTickets), baseProvider);

      return context.Resolve<SpecificationQueryProviderDecorator>(decoratedParam);
    }

    ISpecificationExpression<Ticket> GetSpecification(IEnumerable<Parameter> autofacParams)
    {
      return autofacParams
        .OfType<ConstantParameter>()
        .Where(param => param != null
                        && param.Value != null
                        && typeof(ISpecificationExpression<Ticket>).IsAssignableFrom(param.Value.GetType()))
        .Select(param => (ISpecificationExpression<Ticket>) param.Value)
        .FirstOrDefault();
    }
	}
}
