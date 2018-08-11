using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets.Creation
{
  public class TicketFactoryProvider : IGetsTicketCreator
  {
    readonly Lazy<TicketFactory> baseFactory;
    readonly Queue<Func<ICreatesTicket, ICreatesTicket>> decoratorFactories;

    public IEnumerable<Func<ICreatesTicket, ICreatesTicket>> DecoratorFactories => decoratorFactories;

    public ICreatesTicket GetTicketCreator()
    {
      ICreatesTicket output = baseFactory.Value;

      foreach(var decoratorFactory in DecoratorFactories)
      {
        output = decoratorFactory(output);
      }

      return output;
    }

    public TicketFactoryProvider(Lazy<TicketFactory> baseFactory,
                                 Func<ICreatesTicket, CurrentProjectSettingTicketFactoryDecorator> projectFactory,
                                 Func<ICreatesTicket, CurrentUserSettingTicketFactoryDecorator> userFactory,
                                 Func<ICreatesTicket, LabelPopulatingTicketFactoryDecorator> labelFactory,
                                 Func<ICreatesTicket, PersistingTicketFactoryDecorator> persistingFactory,
                                 Func<ICreatesTicket, SprintPopulatingTicketFactoryDecorator> sprintFactory,
                                 Func<ICreatesTicket, TicketTypePopulatingTicketFactoryDecorator> typeFactory,
                                 Func<ICreatesTicket, RelationshipPopulatingTicketFactoryDecorator> relationshipFactory)
    {
      if(baseFactory == null)
        throw new ArgumentNullException(nameof(baseFactory));
      this.baseFactory = baseFactory;

      decoratorFactories = new Queue<Func<ICreatesTicket, ICreatesTicket>>();
      decoratorFactories.Enqueue(typeFactory);
      decoratorFactories.Enqueue(projectFactory);
      decoratorFactories.Enqueue(userFactory);
      decoratorFactories.Enqueue(labelFactory);
      decoratorFactories.Enqueue(sprintFactory);
      decoratorFactories.Enqueue(relationshipFactory);

      // The persisting decorator is intentionally at the end of the queue,
      // so that it is the 'outermost' decorator, thus everything else happens
      // inside the transaction
      decoratorFactories.Enqueue(persistingFactory);
    }
  }
}
