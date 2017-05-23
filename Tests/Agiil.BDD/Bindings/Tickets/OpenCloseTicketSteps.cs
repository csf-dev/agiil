using System;
using Agiil.Domain.Tickets;
using Agiil.Tests.Tickets;
using CSF.Entities;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class OpenCloseTicketSteps
  {
    readonly IOpenCloseTicketController controller;

    [When(@"the user closes ticket ID (\d+)")]
    public void WhenTheUserClosesATicket(long id)
    {
      var identity = Identity.Create<Ticket>(id);
      controller.Close(identity);
    }

    [When(@"the user reopens ticket ID (\d+)")]
    public void WhenTheUserReopensATicket(long id)
    {
      var identity = Identity.Create<Ticket>(id);
      controller.Reopen(identity);
    }

    [Then(@"ticket ID (\d+) should be open")]
    public void TheTicketShouldBeOpen(long id)
    {
      var identity = Identity.Create<Ticket>(id);
      controller.VerifyOpen(identity);
    }

    [Then(@"ticket ID (\d+) should be closed")]
    public void TheTicketShouldBeClosed(long id)
    {
      var identity = Identity.Create<Ticket>(id);
      controller.VerifyClosed(identity);
    }

    public OpenCloseTicketSteps(IOpenCloseTicketController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      
      this.controller = controller;
    }
  }
}
