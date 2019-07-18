using System;
using CSF.Validation.Rules;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
  public class ChangedTicketRelationshipsRule : Rule<IChangesTicketRelationships>
  {
    readonly IGetsTheoreticalTicketRelationships theoreticalRelationshipProvider;
    readonly IValidatesTheoreticalTicketRelationships relationshipValidator;

    protected override RuleOutcome GetOutcome(IChangesTicketRelationships validated)
    {
      var theoreticalRelationships = theoreticalRelationshipProvider.GetTheoreticalTicketRelationships(
        ticketIdentity: validated.EditedTicket,
        added: validated.RelationshipsToAdd,
        removed: validated.RelationshipsToRemove
      );

      if(relationshipValidator.AreRelationshipsValid(validated.EditedTicket, theoreticalRelationships))
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
