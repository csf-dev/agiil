using System;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketRequest
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public IIdentity<Sprint> SprintIdentity { get; set; }
  }
}
