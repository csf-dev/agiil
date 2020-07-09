using System;
namespace Agiil.Domain.TicketSearch
{
    public class DoesSearchContainProjectCriteriaVisitor : SearchVisitor, IGetsWhetherSearchContainsProjectCriteria
    {
        // Temporary hard-coded implementation, only safe because there
        // is currently no way to specify which project a ticket is within.
        public bool DoesSearchContainAnyProjectCriteria() => false;
    }
}
