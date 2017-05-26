using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Tests.Autofixture;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;
using CSF.Entities;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketCreationSteps
  {
    readonly INewTicketController ticketCreator;
    readonly IBulkTicketCreator bulkTicketCreator;
    readonly IFixture autofixture;
    readonly ITicketModel ticketModel;

    [When("the user attempts to create a ticket with the following properties:")]
    public void TheUserAttemptsToCreateATicket(Table ticketProperties)
    {
      var spec = ticketProperties.CreateInstance<NewTicketSpecification>();
      ticketCreator.Create(spec);
    }

    [Given("there are a number of tickets with the following properties:")]
    public void ThereAreTicketsWithTheFollowingProperties(Table ticketSpecifications)
    {
      autofixture.Customize(new BulkTicketSpecificationCustomization());
      var tickets = ticketSpecifications.CreateSet(() => autofixture.Create<BulkTicketSpecification>());
      bulkTicketCreator.CreateTickets(tickets);
    }

    [Given(@"there is a ticket with ID (\d+)")]
    public void ThereIsATicketWithAnId(long id)
    {
      var ticket = autofixture.Create<BulkTicketSpecification>();
      ticket.Id = id;
      bulkTicketCreator.CreateTickets(new [] { ticket });
    }

    [Given(@"there is no ticket with ID (\d+)")]
    public void ThereIsNotATicketWithAnId(long id)
    {
      var identity = Identity.Create<Ticket>(id);
      ticketModel.Remove(identity);
    }

    public TicketCreationSteps(INewTicketController controller,
                               IBulkTicketCreator bulkTicketCreator,
                               IFixture autofixture,
                               ITicketModel ticketModel)
    {
      if(ticketModel == null)
        throw new ArgumentNullException(nameof(ticketModel));
      if(autofixture == null)
        throw new ArgumentNullException(nameof(autofixture));
      if(bulkTicketCreator == null)
        throw new ArgumentNullException(nameof(bulkTicketCreator));
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));

      this.ticketCreator = controller;
      this.bulkTicketCreator = bulkTicketCreator;
      this.autofixture = autofixture;
      this.ticketModel = ticketModel;
    }
  }
}
