using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public interface ITicketQueryController
  {
    bool DoesTicketExist(TicketSearchCriteria searchHelper = null);

    void VisitTicketListControllerAndStoreListInContext();

    void VisitTicketDetailControllerAndStoreDetail(long id);

    void VerifyThatTicketsAreListedInOrder(IList<TicketSummaryDto> expected);

    void VerifyThatTicketDetailMatchesExpectation(TicketDetailDto expected);

    void VerifyTheUserSeesA404Error();
  }
}
