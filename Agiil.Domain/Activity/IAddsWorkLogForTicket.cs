using System;
namespace Agiil.Domain.Activity
{
  public interface IAddsWorkLogForTicket
  {
    void AddWorkLog(AddWorkLogRequest request);
  }
}
