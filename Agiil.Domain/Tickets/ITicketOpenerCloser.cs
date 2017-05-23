using System;
namespace Agiil.Domain.Tickets
{
  public interface ITicketOpenerCloser
  {
    CloseTicketResponse Close(CloseTicketRequest request);

    ReopenTicketResponse Reopen(ReopenTicketRequest request);
  }
}
