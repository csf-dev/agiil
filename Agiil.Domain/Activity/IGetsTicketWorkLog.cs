using System;
namespace Agiil.Domain.Activity
{
  public interface IGetsTicketWorkLog
  {
    TicketWorkLog GetWorkLog(AddWorkLogRequest request);
  }
}
