using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets.Creation
{
  public class TicketFactoryProvider : IGetsTicketCreator
  {
    readonly Lazy<TicketFactory> baseFactory;
    readonly Stack<Func<ICreatesTicket, ICreatesTicket>> decoratorFactories;

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
                                 Func<ICreatesTicket, TicketTypePopulatingTicketFactoryDecorator> typeFactory)
    {
      if(baseFactory == null)
        throw new ArgumentNullException(nameof(baseFactory));
      this.baseFactory = baseFactory;

      decoratorFactories = new Stack<Func<ICreatesTicket, ICreatesTicket>>();
      decoratorFactories.Push(typeFactory);
      decoratorFactories.Push(projectFactory);
      decoratorFactories.Push(userFactory);
      decoratorFactories.Push(labelFactory);
      decoratorFactories.Push(sprintFactory);
      decoratorFactories.Push(persistingFactory);
    }
  }
}
