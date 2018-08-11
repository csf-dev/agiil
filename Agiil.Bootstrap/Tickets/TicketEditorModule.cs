using System;
using Autofac;
using System.Reflection;
using System.Linq;
using Agiil.Domain;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Editing;

namespace Agiil.Bootstrap.Tickets
{
  public class TicketEditorModule : Autofac.Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      var concreteEditorTypes = GetConcreteEditorTypes();
      builder.RegisterTypes(concreteEditorTypes).AsSelf();

      builder.RegisterType<TicketEditorFactory>().AsSelf().AsImplementedInterfaces();

      builder.Register(ctx => ctx.Resolve<IGetsTicketEditor>().GetTicketEditor());
		}

		Type[] GetConcreteEditorTypes()
    {
      var assembly = Assembly.GetAssembly(typeof(IDomainImplementationAssemblyMarker));
      var editorBaseType = typeof(IEditsTicket);
      var editorNamespace = typeof(TicketEditorFactory).Namespace;

      return (from type in assembly.GetExportedTypes()
              where
              type.IsClass
              && !type.IsAbstract
              && editorBaseType.IsAssignableFrom(type)
              && type.Namespace == editorNamespace
              select type)
        .ToArray();
    }
  }
}
