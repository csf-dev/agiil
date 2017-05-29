using System;
using System.Collections.Generic;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public interface ITicketListController
  {
    void VisitTicketListControllerAndStoreListInContext();

    void VisitTicketDetailControllerAndStoreDetail(long id);

    void VerifyThatTicketsAreListedInOrder(IList<TicketSummaryDto> expected);

    void VerifyThatTicketDetailMatchesExpectation(TicketDetailDto expected);

    void VerifyTheUserSeesA404Error();
  }
}
