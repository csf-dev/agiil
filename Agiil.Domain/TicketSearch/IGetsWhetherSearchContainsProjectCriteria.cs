using System;
namespace Agiil.Domain.TicketSearch
{
    public interface IGetsWhetherSearchContainsProjectCriteria : IVisitsTicketSearch
    {
        bool DoesSearchContainAnyProjectCriteria();
    }
}
