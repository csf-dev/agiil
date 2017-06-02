using System;
namespace Agiil.Domain
{
  public interface IHasStartAndEndDates
  {
    DateTime? StartDate { get; }
    DateTime? EndDate { get; }
  }
}
