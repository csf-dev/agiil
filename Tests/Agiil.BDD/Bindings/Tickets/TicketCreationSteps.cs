using System;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketCreationSteps
  {
    readonly INewTicketController controller;

    [When("the user attempts to create a ticket with the following properties:")]
    public void TheUserAttemptsToCreateATicket(Table ticketProperties)
    {
      var spec = ticketProperties.CreateInstance<NewTicketSpecification>();
      controller.Create(spec);
    }

    public TicketCreationSteps(INewTicketController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));

      this.controller = controller;
    }
  }
}
