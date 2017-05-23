using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models
{
  public class EditTicketTitleAndDescriptionSpecification
  {
    public IIdentity<Ticket> Identity { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
  }
}
