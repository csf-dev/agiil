using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Agiil.Tests.Tickets;
using Agiil.Web.Models;
using System.Linq.Expressions;
using Agiil.Domain.Tickets;
using NUnit.Framework;
using System.Linq;
using Agiil.Web.Models.Tickets;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketQuerySteps
  {
    readonly ITicketQueryController queryController;
    readonly ITicketListController listController;

    [When("the user visits the ticket list page")]
    public void TheUserVisitsTheTicketListPage()
    {
      listController.VisitTicketListControllerAndStoreListInContext();
    }

    [When("the user visits the ticket detail page for ticket ID (\\d+)")]
    public void TheUserVisitsTheTicketDetailPage(long id)
    {
      listController.VisitTicketDetailControllerAndStoreDetail(id);
    }

    [Then("a ticket should exist with the following properties:")]
    public void ATicketShouldBeCreated(Table ticketProperties)
    {
      if(ticketProperties == null)
        throw new ArgumentNullException(nameof(ticketProperties));

      var criteria = ticketProperties.CreateInstance<TicketSearchCriteria>();
      Assert.IsTrue(queryController.DoesTicketExist(criteria));
    }

    [Then("no ticket should exist matching the following properties:")]
    public void ATicketShouldNotBeCreated(Table ticketProperties)
    {
      if(ticketProperties == null)
        throw new ArgumentNullException(nameof(ticketProperties));

      var criteria = ticketProperties.CreateInstance<TicketSearchCriteria>();
      Assert.IsFalse(queryController.DoesTicketExist(criteria));
    }

    [Then("the following ticket summaries should be displayed, in order:")]
    public void TheFollowingTicketsShouldBeDisplayed(Table ticketProperties)
    {
      if(ticketProperties == null)
        throw new ArgumentNullException(nameof(ticketProperties));

      var tickets = ticketProperties.CreateSet<TicketSummaryDto>().ToList();
      listController.VerifyThatTicketsAreListedInOrder(tickets);
    }

    [Then("the following ticket detail should be displayed:")]
    public void TheFollowingTicketShouldBeDisplayed(Table ticketProperties)
    {
      if(ticketProperties == null)
        throw new ArgumentNullException(nameof(ticketProperties));

      var ticket = ticketProperties.CreateInstance<TicketDetailDto>();
      listController.VerifyThatTicketDetailMatchesExpectation(ticket);
    }

    [Then("the user sees a 404 error page")]
    public void TheUserSeesA404ErrorPage()
    {
      listController.VerifyTheUserSeesA404Error();
    }

    public TicketQuerySteps(ITicketQueryController queryController,
                            ITicketListController listController)
    {
      if(listController == null)
        throw new ArgumentNullException(nameof(listController));
      if(queryController == null)
        throw new ArgumentNullException(nameof(queryController));

      this.queryController = queryController;
      this.listController = listController;
    }
  }
}
