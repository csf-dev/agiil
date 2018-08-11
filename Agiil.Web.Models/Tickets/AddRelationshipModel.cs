using System;
using Agiil.Domain.Tickets;

namespace Agiil.Web.Models.Tickets
{
  public class AddRelationshipModel
  {
    public string RelationshipIdAndParticipation { get; set; }

    public TicketReference RelatedTicketReference { get; set; }
  }
}
