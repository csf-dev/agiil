using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Labels
{
  public class LabelTicketProvider : IGetsTicketsWithLabel
  {
    readonly IGetsListOfTickets ticketLister;

    public IReadOnlyCollection<Ticket> GetAllClosedTickets(string labelName)
      => GetAllTickets(labelName, false);

    public IReadOnlyCollection<Ticket> GetAllClosedTickets(Label label)
      => GetAllClosedTickets(label?.Name);

    public IReadOnlyCollection<Ticket> GetAllOpenTickets(string labelName)
      => GetAllTickets(labelName, true);

    public IReadOnlyCollection<Ticket> GetAllOpenTickets(Label label)
      => GetAllOpenTickets(label?.Name);

    IReadOnlyCollection<Ticket> GetAllTickets(string labelName, bool open)
    {
      var openClosed = open ? WellKnownValue.Open : WellKnownValue.Closed;

      var listRequest = new TicketListRequest {
        SearchModel = new Search {
          CriteriaRoot = new CriteriaRoot {
            Criteria = new [] {
              Criterion.FromElementPredicateAndConstantValue(ElementName.Label, PredicateName.Equals, labelName),
              Criterion.FromElementPredicateAndConstantValue(ElementName.Ticket, PredicateName.Is, openClosed)
            }
          }
        }
      };

      return ticketLister.GetTickets(listRequest);
    }

    public LabelTicketProvider(IGetsListOfTickets ticketLister)
    {
      if(ticketLister == null)
        throw new ArgumentNullException(nameof(ticketLister));
      this.ticketLister = ticketLister;
    }
  }
}
