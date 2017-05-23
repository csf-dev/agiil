using System;
namespace Agiil.Domain
{
  public class CurrentEnvironment : IEnvironment
  {
    public DateTime GetCurrentUtcTimestamp()
    {
      return DateTime.UtcNow;
    }

    public DateTime GetCurrentLocalTimestamp()
    {
      return DateTime.Now;
    }
  }
}
