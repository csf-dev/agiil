using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class NewTicketResponse
  {
    public IIdentity<Ticket> TicketIdentity { get; set; }

    public bool TitleIsInvalid { get; set; }

    public bool DescriptionIsInvalid { get; set; }

    public bool SprintIsInvalid { get; set; }

    public bool Success => !ReferenceEquals(TicketIdentity, null);
  }
}
