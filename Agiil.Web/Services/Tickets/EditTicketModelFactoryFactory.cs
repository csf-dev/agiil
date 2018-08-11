using System;
using System.Collections.Generic;

namespace Agiil.Web.Services.Tickets
{
  public class EditTicketModelFactoryFactory : IGetsEditTicketModelFactory
  {
    Func<MappingEditTicketModelFactory> baseFactory;
    Queue<Func<IGetsEditTicketModel,IGetsEditTicketModel>> decoratorFactories;

    public IGetsEditTicketModel GetEditTicketModelFactory()
    {
      IGetsEditTicketModel output = baseFactory();

      foreach(var decoratorFactory in decoratorFactories)
      {
        output = decoratorFactory(output);
      }

      return output;
    }

    public EditTicketModelFactoryFactory(Func<MappingEditTicketModelFactory> baseFactory,
                                         Func<IGetsEditTicketModel,TempDataRestoringEditTicketModelFactoryDecorator> tempDataFactory,
                                         Func<IGetsEditTicketModel,AvailableRelationshipsTicketModelFactoryDecorator> relationshipFactory,
                                         Func<IGetsEditTicketModel,AvailableSprintsTicketModelFactoryDecorator> sprintFactory,
                                         Func<IGetsEditTicketModel,AvailableTicketTypesTicketModelFactoryDecorator> ticketTypeFactory)
    {
      this.baseFactory = baseFactory;

      decoratorFactories = new Queue<Func<IGetsEditTicketModel, IGetsEditTicketModel>>();

      decoratorFactories.Enqueue(tempDataFactory);
      decoratorFactories.Enqueue(relationshipFactory);
      decoratorFactories.Enqueue(sprintFactory);
      decoratorFactories.Enqueue(ticketTypeFactory);
    }
  }
}
