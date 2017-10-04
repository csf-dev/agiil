using System;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class NewTicketSpecification
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public IIdentity<Sprint> SprintIdentity { get; set; }

    public IIdentity<TicketType> TicketTypeIdentity { get; set; }

    public long? SprintId
    {
      get { return (long?) SprintIdentity?.Value; }
      set {
        if(!value.HasValue)
          SprintIdentity = null;

        SprintIdentity = Identity.Create<Sprint>(value.Value);
      }
    }

    public long? TicketTypeId
    {
      get { return (long?) TicketTypeIdentity?.Value; }
      set {
        if(!value.HasValue)
          TicketTypeIdentity = null;

        TicketTypeIdentity = Identity.Create<TicketType>(value.Value);
      }
    }
  }
}
