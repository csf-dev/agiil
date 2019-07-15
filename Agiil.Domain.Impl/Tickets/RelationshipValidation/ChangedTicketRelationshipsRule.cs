using System;
using System.Collections.Generic;
using CSF.Entities;
using CSF.Validation.Rules;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class ChangedTicketRelationshipsRule : Rule
  {
    readonly IGetsTheoreticalTicketRelationships theoreticalRelationshipProvider;
    readonly IValidatesTheoreticalTicketRelationships relationshipValidator;

    public IIdentity<Ticket> EditedTicketIdentity { get; set; }
    public IEnumerable<AddRelationshipRequest> RelationshipsAdded { get; set; }
    public IEnumerable<DeleteRelationshipRequest> RelationshipsRemoved { get; set; }

    protected override RuleOutcome GetOutcome(object validated)
    {
      var theoreticalRelationships = theoreticalRelationshipProvider.GetTheoreticalTicketRelationships(
        ticketIdentity: EditedTicketIdentity,
        added: RelationshipsAdded,
        removed: RelationshipsRemoved
      );

      if(relationshipValidator.AreRelationshipsValid(EditedTicketIdentity, theoreticalRelationships))
        return Success;

      return Failure;
    }

    public ChangedTicketRelationshipsRule(IGetsTheoreticalTicketRelationships theoreticalRelationshipProvider,
                                          IValidatesTheoreticalTicketRelationships relationshipValidator)
    {
      this.theoreticalRelationshipProvider = theoreticalRelationshipProvider ?? throw new ArgumentNullException(nameof(theoreticalRelationshipProvider));
      this.relationshipValidator = relationshipValidator ?? throw new ArgumentNullException(nameof(relationshipValidator));
    }
  }
}
