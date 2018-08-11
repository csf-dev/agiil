using System;
using Autofac;
using System.Reflection;
using System.Linq;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Creation;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketFactoryModule : Autofac.Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      var concreteCreatorTypes = GetConcreteCreatorTypes();
      builder.RegisterTypes(concreteCreatorTypes).AsSelf();

      builder.RegisterType<TicketFactoryProvider>().AsSelf().AsImplementedInterfaces();

      builder.Register(ctx => ctx.Resolve<IGetsTicketCreator>().GetTicketCreator());
		}

    Type[] GetConcreteCreatorTypes()
    {
      var assembly = Assembly.GetAssembly(typeof(IDomainImplementationAssemblyMarker));
      var creatorBaseType = typeof(ICreatesTicket);
      var creationNamespace = typeof(TicketFactoryProvider).Namespace;

      return (from type in assembly.GetExportedTypes()
              where
                type.IsClass
                && !type.IsAbstract
                && creatorBaseType.IsAssignableFrom(type)
                && type.Namespace == creationNamespace
              select type)
        .ToArray();
    }
	}
}
