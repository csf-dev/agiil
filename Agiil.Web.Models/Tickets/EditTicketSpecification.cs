using System;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class EditTicketSpecification
  {
    public IIdentity<Ticket> Identity { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IIdentity<Sprint> SprintIdentity { get; set; }

    public IIdentity<TicketType> TicketTypeIdentity { get; set; }
  }
}
