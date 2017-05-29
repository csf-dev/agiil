using System;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class NewTicketSpecification
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public IIdentity<Sprint> SprintIdentity { get; set; }

    public long? SprintId
    {
      get { return (long?) SprintIdentity?.Value; }
      set {
        if(!value.HasValue)
          SprintIdentity = null;

        SprintIdentity = Identity.Create<Sprint>(value.Value);
      }
    }
  }
}
