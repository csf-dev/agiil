using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;
using Agiil.Web.Models;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  public class TicketQueryController : ITicketQueryController
  {
    readonly IRepository<Ticket> repo;
    readonly TicketListModelContext ticketListContext;
    readonly Func<TicketsController> ticketListControllerFactory;

    public bool DoesTicketExist(TicketSearchCriteria searchHelper = null)
    {
      var predicate = CreateTicketSearchPredicate(searchHelper);
      return repo.Query().AnyCount(predicate);
    }

    public void VerifyThatTicketsAreListedInOrder(IList<TicketSummaryDto> expected)
    {
      var actual = ticketListContext.Model.Tickets;
      CollectionAssert.AreEqual(expected, actual);
    }

    public void VisitTicketListControllerAndStoreListInContext()
    {
      var controller = ticketListControllerFactory();
      var result = (ViewResult) controller.Index();
      var model = (TicketListModel) result.Model;

      ticketListContext.Model = model;
    }

    Expression<Func<Ticket,bool>> CreateTicketSearchPredicate(TicketSearchCriteria helper)
    {
      if(helper == null)
        return t => true;

      return t => ((String.IsNullOrWhiteSpace(helper.Title) || t.Title == helper.Title.Trim())
                   && (String.IsNullOrWhiteSpace(helper.Description) || t.Description == helper.Description.Trim())
                   && (String.IsNullOrWhiteSpace(helper.User) || (t.User != null && t.User.Username == helper.User.Trim())));

    }

    public TicketQueryController(IRepository<Ticket> repo,
                                 TicketListModelContext ticketListContext,
                                 Func<TicketsController> ticketListControllerFactory)
    {
      if(ticketListControllerFactory == null)
        throw new ArgumentNullException(nameof(ticketListControllerFactory));
      if(ticketListContext == null)
        throw new ArgumentNullException(nameof(ticketListContext));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));

      this.repo = repo;
      this.ticketListContext = ticketListContext;
      this.ticketListControllerFactory = ticketListControllerFactory;
    }
  }
}
