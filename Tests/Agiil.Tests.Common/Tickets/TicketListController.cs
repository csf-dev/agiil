using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Tickets;
using CSF.Entities;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  public class TicketListController : ITicketListController
  {
    readonly TicketListModelContext ticketListContext;
    readonly TicketDetailModelContext ticketDetailContext;
    readonly Func<TicketsController> ticketListControllerFactory;
    readonly Func<TicketController> ticketDetailControllerFactory;

    public void VerifyThatTicketsAreListedInOrder(IList<TicketSummaryDto> expected)
    {
      var actual = ticketListContext.Model.Tickets;
      CollectionAssert.AreEqual(expected, actual, new TicketSummaryDtoComparer());
    }

    public void VerifyThatTicketDetailMatchesExpectation(TicketDetailDto expected)
    {
      var actual = ticketDetailContext.Model.Ticket;
      Assert.IsTrue(new TicketDetailDtoComparer().Equals(expected, actual), "Instances are equal");
    }

    public void VerifyTheUserSeesA404Error()
    {
      Assert.IsTrue(ticketDetailContext.NotFound, "Not found error response");
      Assert.IsNull(ticketDetailContext.Model, "No ticket model associated");
    }

    public void VisitTicketListControllerAndStoreListInContext()
    {
      var controller = ticketListControllerFactory();
      var result = (ViewResult) controller.Index(null);
      var model = (TicketListModel) result.Model;

      ticketListContext.Model = model;
    }

    public void VisitTicketDetailControllerAndStoreDetail(long id)
    {
      var controller = ticketDetailControllerFactory();
      var result = controller.Index(Identity.Create<Ticket>(id));

      if(result is HttpNotFoundResult)
      {
        ticketDetailContext.NotFound = true;
        return;
      }

      var viewResult = (ViewResult) result;
      ticketDetailContext.Model = (TicketDetailModel) viewResult.Model;
    }

    public TicketListController(TicketListModelContext ticketListContext,
                                 Func<TicketsController> ticketListControllerFactory,
                                 Func<TicketController> ticketDetailControllerFactory,
                                 TicketDetailModelContext ticketDetailContext)
    {
      if(ticketDetailContext == null)
        throw new ArgumentNullException(nameof(ticketDetailContext));
      if(ticketDetailControllerFactory == null)
        throw new ArgumentNullException(nameof(ticketDetailControllerFactory));
      if(ticketListControllerFactory == null)
        throw new ArgumentNullException(nameof(ticketListControllerFactory));
      if(ticketListContext == null)
        throw new ArgumentNullException(nameof(ticketListContext));

      this.ticketListContext = ticketListContext;
      this.ticketListControllerFactory = ticketListControllerFactory;
      this.ticketDetailControllerFactory = ticketDetailControllerFactory;
      this.ticketDetailContext = ticketDetailContext;
    }
  }
}
