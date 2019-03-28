using System;
namespace Agiil.Domain.Activity
{
  public interface IGetsTicketWorkLog
  {
    GetWorklogResponse GetWorkLog(AddWorkLogRequest request);
  }
}
