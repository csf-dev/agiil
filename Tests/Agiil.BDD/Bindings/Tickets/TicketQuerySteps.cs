using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using System.Linq.Expressions;
using Agiil.Domain.Tickets;
using NUnit.Framework;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketQuerySteps
  {
    readonly ITicketQueryController queryController;

    [Then("a ticket should be created with the following properties:")]
    public void ATicketShouldBeCreated(Table ticketProperties)
    {
      if(ticketProperties == null)
        throw new ArgumentNullException(nameof(ticketProperties));

      var criteria = ticketProperties.CreateInstance<TicketSearchCriteria>();
      Assert.IsTrue(queryController.DoesTicketExist(criteria));
    }

    public TicketQuerySteps(ITicketQueryController queryController)
    {
      if(queryController == null)
        throw new ArgumentNullException(nameof(queryController));

      this.queryController = queryController;
    }
  }
}
