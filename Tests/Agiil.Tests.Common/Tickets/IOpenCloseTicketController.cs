using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Tests.Tickets
{
  public interface IOpenCloseTicketController
  {
    void Close(IIdentity<Ticket> id);
    void Reopen(IIdentity<Ticket> id);
    void VerifyOpen(IIdentity<Ticket> id);
    void VerifyClosed(IIdentity<Ticket> id);
  }
}
