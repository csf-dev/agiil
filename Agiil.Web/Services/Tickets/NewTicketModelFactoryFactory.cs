using System;
using System.Collections.Generic;

namespace Agiil.Web.Services.Tickets
{
  public class NewTicketModelFactoryFactory : IGetsNewTicketModelFactory
  {
    Func<SpecificationBasedNewTicketModelFactory> baseFactory;
    Queue<Func<IGetsNewTicketModel,IGetsNewTicketModel>> decoratorFactories;

    public IGetsNewTicketModel GetNewTicketModelFactory()
    {
      IGetsNewTicketModel output = baseFactory();

      foreach(var decoratorFactory in decoratorFactories)
      {
        output = decoratorFactory(output);
      }

      return output;
    }

    public NewTicketModelFactoryFactory(Func<SpecificationBasedNewTicketModelFactory> baseFactory,
                                        Func<IGetsNewTicketModel,AvailableRelationshipsNewTicketModelFactoryDecorator> relationshipFactory,
                                        Func<IGetsNewTicketModel,AvailableSprintsNewTicketModelFactoryDecorator> sprintFactory,
                                        Func<IGetsNewTicketModel,AvailableTicketTypesNewTicketModelFactoryDecorator> ticketTypeFactory)
    {
      this.baseFactory = baseFactory;

      decoratorFactories = new Queue<Func<IGetsNewTicketModel, IGetsNewTicketModel>>();

      decoratorFactories.Enqueue(relationshipFactory);
      decoratorFactories.Enqueue(sprintFactory);
      decoratorFactories.Enqueue(ticketTypeFactory);
    }
  }
}
