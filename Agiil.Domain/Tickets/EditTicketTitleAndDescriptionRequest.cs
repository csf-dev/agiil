using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class EditTicketTitleAndDescriptionRequest
  {
    public IIdentity<Ticket> Identity { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
  }
}
