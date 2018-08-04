using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets.Editing
{
  public class TicketEditorFactory : IGetsTicketEditor
  {
    readonly Lazy<AutomapperBasedTicketEditor> baseFactory;
    readonly Stack<Func<IEditsTicket, IEditsTicket>> decoratorFactories;

    public IEnumerable<Func<IEditsTicket, IEditsTicket>> DecoratorFactories => decoratorFactories;

    public IEditsTicket GetTicketEditor()
    {
      IEditsTicket output = baseFactory.Value;

      foreach(var decoratorFactory in DecoratorFactories)
      {
        output = decoratorFactory(output);
      }

      return output;
    }

    public TicketEditorFactory(Lazy<AutomapperBasedTicketEditor> baseFactory,
                               Func<IEditsTicket,LabelResolvingTicketEditorDecorator> labelDecorator,
                               Func<IEditsTicket,RelationshipAddingTicketEditorDecorator> relationshipAddingDecorator,
                               Func<IEditsTicket,RelationshipRemovingTicketEditorDecorator> relationshipRemovingDecorator)
    {
      if(baseFactory == null)
        throw new ArgumentNullException(nameof(baseFactory));
      this.baseFactory = baseFactory;

      decoratorFactories = new Stack<Func<IEditsTicket, IEditsTicket>>();
      decoratorFactories.Push(labelDecorator);
      decoratorFactories.Push(relationshipAddingDecorator);
      decoratorFactories.Push(relationshipRemovingDecorator);
    }
  }
}
