using System;
using System.Collections.Generic;
using Agiil.Domain.Sprints;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class EditTicketRequest : IChangesTicketRelationships
  {
    ICollection<AddRelationshipRequest> relationshipsToAdd;
    ICollection<DeleteRelationshipRequest> relationshipsToRemove;

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

    public ICollection<DeleteRelationshipRequest> RelationshipsToRemove
    {
      get { return relationshipsToRemove; }
      set { relationshipsToRemove = value ?? new List<DeleteRelationshipRequest>(); }
    }

    public int? StoryPoints { get; set; }

    IIdentity<Ticket> IChangesTicketRelationships.EditedTicket => Identity;

    IEnumerable<AddRelationshipRequest> IChangesTicketRelationships.RelationshipsToAdd => RelationshipsToAdd;

    IEnumerable<DeleteRelationshipRequest> IChangesTicketRelationships.RelationshipsToRemove => RelationshipsToRemove;

    public EditTicketRequest()
    {
      relationshipsToAdd = new List<AddRelationshipRequest>();
      relationshipsToRemove = new List<DeleteRelationshipRequest>();
    }
  }
}
