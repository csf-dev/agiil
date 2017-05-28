using System;
namespace Agiil.Domain.Tickets
{
  public interface ITicketEditor
  {
    EditTicketResponse Edit(EditTicketRequest request);
  }
}
