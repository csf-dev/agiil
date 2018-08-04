using System;
namespace Agiil.Domain.Tickets
{
  public interface IHandlesEditTicketRequest
  {
    EditTicketResponse Edit(EditTicketRequest request);
  }
}
