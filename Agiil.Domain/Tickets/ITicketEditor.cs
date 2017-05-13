using System;
namespace Agiil.Domain.Tickets
{
  public interface ITicketEditor
  {
    EditTicketTitleAndDescriptionResponse Edit(EditTicketTitleAndDescriptionRequest request);
  }
}
