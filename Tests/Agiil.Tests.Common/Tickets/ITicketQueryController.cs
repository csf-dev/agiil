using System.Collections.Generic;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public interface ITicketQueryController
  {
    bool DoesTicketExist(TicketSearchCriteria criteria = null);
  }
}
