using System;
using System.Collections.Generic;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class EditTicketSpecification
  {
    List<AddRelationshipModel> relationshipsToAdd;
    List<IIdentity<TicketRelationship>> relationshipsToRemove;

    public IIdentity<Ticket> Identity { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string CommaSeparatedLabelNames { get; set; }

    public IIdentity<Sprint> SprintIdentity { get; set; }

    public IIdentity<TicketType> TicketTypeIdentity { get; set; }

    public List<AddRelationshipModel> RelationshipsToAdd
    {
      get { return relationshipsToAdd; }
      set { relationshipsToAdd = value ?? new List<AddRelationshipModel>(); }
    }

    public List<IIdentity<TicketRelationship>> RelationshipsToRemove
    {
      get { return relationshipsToRemove; }
      set { relationshipsToRemove = value ?? new List<IIdentity<TicketRelationship>>(); }
    }

    public EditTicketSpecification()
    {
      relationshipsToAdd = new List<AddRelationshipModel>();
      relationshipsToRemove = new List<IIdentity<TicketRelationship>>();
    }
  }
}
