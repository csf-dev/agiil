using System;
using System.Collections.Generic;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class EditTicketRequest
  {
    ICollection<AddRelationshipRequest> relationshipsToAdd;
    ICollection<DeleteRelationshipRequest> relationshipsToDelete;

    public IIdentity<Ticket> Identity { get; set; }

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

    public ICollection<DeleteRelationshipRequest> RelationshipsToDelete
    {
      get { return relationshipsToDelete; }
      set { relationshipsToDelete = value ?? new List<DeleteRelationshipRequest>(); }
    }

    public EditTicketRequest()
    {
      relationshipsToAdd = new List<AddRelationshipRequest>();
      relationshipsToDelete = new List<DeleteRelationshipRequest>();
    }
  }
}
