using System;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class EditTicketRequest
  {
    public IIdentity<Ticket> Identity { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IIdentity<Sprint> SprintIdentity { get; set; }

    public IIdentity<TicketType> TicketTypeIdentity { get; set; }
  }
}
