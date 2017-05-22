using System;
using Agiil.Domain.Tickets;
using CSF.Data.Entities;
using CSF.Entities;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  public class OpenCloseTicketController : IOpenCloseTicketController
  {
    readonly Web.Controllers.OpenCloseTicketController webController;
    readonly IRepository<Ticket> ticketRepo;

    public void Close(IIdentity<Ticket> id)
    {
      webController.Close(id);
    }

    public void Reopen(IIdentity<Ticket> id)
    {
      webController.Reopen(id);
    }

    public void VerifyClosed(IIdentity<Ticket> id)
    {
      var ticket = ticketRepo.Get(id);
      Assert.NotNull(ticket, "Ticket must not be null");
      Assert.IsTrue(ticket.Closed, "Ticket must be closed");
    }

    public void VerifyOpen(IIdentity<Ticket> id)
    {
      var ticket = ticketRepo.Get(id);
      Assert.NotNull(ticket, "Ticket must not be null");
      Assert.IsFalse(ticket.Closed, "Ticket must be open");
    }

    public OpenCloseTicketController(Web.Controllers.OpenCloseTicketController webController,
                                     IRepository<Ticket> ticketRepo)
    {
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));
      this.ticketRepo = ticketRepo;
      this.webController = webController;
    }
  }
}
