using System;
using CSF.Validation.Rules;
using log4net;

namespace Agiil.Domain.Tickets.RelationshipValidation
{
    public class ChangedTicketRelationshipsRule : Rule<IChangesTicketRelationships>
    {
        readonly IGetsTheoreticalTicketRelationships theoreticalRelationshipProvider;
        readonly IValidatesTheoreticalTicketRelationships relationshipValidator;
        readonly ILog logger;

        protected override RuleOutcome GetOutcome(IChangesTicketRelationships validated)
        {
            var theoreticalRelationships = theoreticalRelationshipProvider.GetTheoreticalTicketRelationships(
              ticketIdentity: validated.EditedTicket,
              added: validated.RelationshipsToAdd,
              removed: validated.RelationshipsToRemove
            );

            if(logger.IsDebugEnabled)
                logger.Debug($"Theoretical relationships: {String.Join(", ", theoreticalRelationships)}");

            if(relationshipValidator.AreRelationshipsValid(validated.EditedTicket, theoreticalRelationships))
                return Success;

            return Failure;
        }

        public ChangedTicketRelationshipsRule(IGetsTheoreticalTicketRelationships theoreticalRelationshipProvider,
                                              IValidatesTheoreticalTicketRelationships relationshipValidator,
                                              ILog logger)
        {
            this.theoreticalRelationshipProvider = theoreticalRelationshipProvider ?? throw new ArgumentNullException(nameof(theoreticalRelationshipProvider));
            this.relationshipValidator = relationshipValidator ?? throw new ArgumentNullException(nameof(relationshipValidator));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
