using System;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public class EditTicketController : IEditTicketController
  {
    readonly Web.Controllers.TicketController webController;

    public void Edit(EditTicketTitleAndDescriptionSpecification request)
    {
      webController.Edit(request);
    }

    public EditTicketController(Web.Controllers.TicketController webController)
    {
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));

      this.webController = webController;
    }
  }
}
