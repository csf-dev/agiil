using System;
using System.Linq;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketCreationSteps
  {
    readonly INewTicketController ticketCreator;
    readonly IBulkTicketCreator bulkTicketCreator;

    [When("the user attempts to create a ticket with the following properties:")]
    public void TheUserAttemptsToCreateATicket(Table ticketProperties)
    {
      var spec = ticketProperties.CreateInstance<NewTicketSpecification>();
      ticketCreator.Create(spec);
    }

    [Given("there are a number of tickets with the following properties:")]
    public void ThereAreTicketsWithTheFollowingProperties(Table ticketSpecifications)
    {
      var tickets = ticketSpecifications.CreateSet<BulkTicketSpecification>();
      bulkTicketCreator.CreateTickets(tickets);
    }

    public TicketCreationSteps(INewTicketController controller,
                               IBulkTicketCreator bulkTicketCreator)
    {
      if(bulkTicketCreator == null)
        throw new ArgumentNullException(nameof(bulkTicketCreator));
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));

      this.ticketCreator = controller;
      this.bulkTicketCreator = bulkTicketCreator;
    }
  }
}
