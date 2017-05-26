using System.Collections.Generic;
using Agiil.Web.Models.Tickets;

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
