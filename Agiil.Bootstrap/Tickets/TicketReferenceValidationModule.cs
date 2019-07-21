using System;
using Agiil.Domain.Tickets.RelationshipValidation;
using Autofac;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketReferenceValidationModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      RegisterValidatorService(builder);
    }

    void RegisterValidatorService(ContainerBuilder builder)
    {
      builder.Register(GetValidator);
    }

    IValidatesTheoreticalTicketRelationships GetValidator(IComponentContext ctx)
    {
      IValidatesTheoreticalTicketRelationships impl = ctx.Resolve<CircularRelationshipValidator>();
      impl = ctx.Resolve<MultipleSecondaryRelationshipPreventingValidationDecorator>(TypedParameter.From(impl));
      return impl;
    }
  }
}
