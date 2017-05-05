using System;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public class NewTicketController : INewTicketController
  {
    readonly Web.Controllers.NewTicketController webController;

    public void Create(NewTicketModel request)
    {
      webController.Create(request);
    }

    public NewTicketController(Web.Controllers.NewTicketController webController)
    {
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));

      this.webController = webController;
    }
  }
}
