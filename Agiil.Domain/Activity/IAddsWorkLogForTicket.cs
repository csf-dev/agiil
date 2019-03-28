using System;
namespace Agiil.Domain.Activity
{
  public interface IAddsWorkLogForTicket
  {
    AddWorklogResponse AddWorkLog(AddWorkLogRequest request);
  }
}
