using System;
using System.Collections.Generic;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketRequest
  {
    ICollection<AddRelationshipRequest> relationshipsToAdd;

    public string Title { get; set; }

    public string Description { get; set; }

    public string CommaSeparatedLabelNames { get; set; }

    public IIdentity<Sprint> SprintIdentity { get; set; }

    public IIdentity<TicketType> TicketTypeIdentity { get; set; }

    public ICollection<AddRelationshipRequest> RelationshipsToAdd
    {
      get { return relationshipsToAdd; }
      set { relationshipsToAdd = value ?? new List<AddRelationshipRequest>(); }
    }

    public CreateTicketRequest()
    {
      relationshipsToAdd = new List<AddRelationshipRequest>();
    }
  }
}
