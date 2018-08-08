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

    Func<IGetsEditTicketModel,IGetsEditTicketModel> GetTempDataFactory(Func<IGetsEditTicketModel,IGetsTempData,TempDataRestoringEditTicketModelFactoryDecorator> originalFactory,
                                                                       IGetsTempData tempDataProvider)
    {
      return wrapped => originalFactory(wrapped, tempDataProvider);
    }

    public EditTicketModelFactoryFactory(Func<MappingEditTicketModelFactory> baseFactory,
                                         Func<IGetsEditTicketModel,IGetsTempData,TempDataRestoringEditTicketModelFactoryDecorator> tempDataFactory,
                                         Func<IGetsEditTicketModel,AvailableRelationshipsEditTicketModelFactoryDecorator> relationshipFactory,
                                         Func<IGetsEditTicketModel,AvailableSprintsEditTicketModelFactoryDecorator> sprintFactory,
                                         Func<IGetsEditTicketModel,AvailableTicketTypesEditTicketModelFactoryDecorator> ticketTypeFactory,
                                         IGetsTempData tempDataProvider)
    {
      this.baseFactory = baseFactory;

      decoratorFactories = new Queue<Func<IGetsEditTicketModel, IGetsEditTicketModel>>();

      decoratorFactories.Enqueue(GetTempDataFactory(tempDataFactory, tempDataProvider));
      decoratorFactories.Enqueue(relationshipFactory);
      decoratorFactories.Enqueue(sprintFactory);
      decoratorFactories.Enqueue(ticketTypeFactory);
    }
  }
}
