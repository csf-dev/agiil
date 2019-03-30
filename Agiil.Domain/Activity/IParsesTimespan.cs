using System;
namespace Agiil.Domain.Activity
{
  public interface IParsesTimespan
  {
    TimeSpan GetTimeSpan(string timeAmount);
  }
}
