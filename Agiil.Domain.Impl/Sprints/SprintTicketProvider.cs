using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Sprints
{
  public class SprintTicketProvider : IGetsTicketsInSprint
  {
    readonly IGetsListOfTickets ticketLister;

    public IReadOnlyCollection<Ticket> GetAllClosedTickets(string sprintName)
      => GetAllTickets(sprintName, false);

    public IReadOnlyCollection<Ticket> GetAllClosedTickets(Sprint sprint)
      => GetAllClosedTickets(sprint?.Name);

    public IReadOnlyCollection<Ticket> GetAllOpenTickets(string sprintName)
      => GetAllTickets(sprintName, true);

    public IReadOnlyCollection<Ticket> GetAllOpenTickets(Sprint sprint)
      => GetAllOpenTickets(sprint?.Name);

    IReadOnlyCollection<Ticket> GetAllTickets(string sprintName, bool open)
    {
      var openClosed = open ? WellKnownValue.Open : WellKnownValue.Closed;

      var listRequest = new TicketListRequest {
        SearchModel = new Search {
          CriteriaRoot = new CriteriaRoot {
            Criteria = new [] {
              Criterion.FromElementPredicateAndConstantValue(ElementName.Sprint, PredicateName.Equals, sprintName),
              Criterion.FromElementPredicateAndConstantValue(ElementName.Ticket, PredicateName.Is, openClosed)
            }
          }
        }
      };

      return ticketLister.GetTickets(listRequest);
    }

    public SprintTicketProvider(IGetsListOfTickets ticketLister)
    {
      if(ticketLister == null)
        throw new ArgumentNullException(nameof(ticketLister));
      this.ticketLister = ticketLister;
    }
  }
}
