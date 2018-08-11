using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Tickets;

namespace Agiil.Web.Services.Tickets
{
  public class TempDataRestoringEditTicketModelFactoryDecorator : IGetsEditTicketModel
  {
    readonly IGetsTempData tempData;
    readonly IGetsEditTicketModel wrapped;

    public EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      var model = wrapped.GetEditTicketModel(ticket);

      model.Response = tempData.TryGet<Models.Tickets.EditTicketResponse>(TicketController.EditTicketResponseKey);
      model.Specification = tempData.TryGet<EditTicketSpecification>(TicketController.EditTicketSpecKey);

      return model;
    }

    public TempDataRestoringEditTicketModelFactoryDecorator(IGetsTempData tempData, IGetsEditTicketModel wrapped)
    {
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      if(tempData == null)
        throw new ArgumentNullException(nameof(tempData));
      this.tempData = tempData;
      this.wrapped = wrapped;
    }
  }
}
