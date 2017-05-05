using System;
using Agiil.Domain;
using Ploeh.AutoFixture;

namespace Agiil.Tests
{
  public class RandomEnvironment : IEnvironment
  {
    readonly IFixture autofixture;
    DateTime currentUtcTimestamp;

    public DateTime CurrentUtcTimestamp => currentUtcTimestamp;

    public DateTime GetCurrentUtcTimestamp()
    {
      return CurrentUtcTimestamp;
    }

    public DateTime GetCurrentLocalTimestamp()
    {
      return CurrentUtcTimestamp.ToLocalTime();
    }

    public RandomEnvironment()
    {
      autofixture = new Fixture();
      currentUtcTimestamp = autofixture.Create<DateTime>();
    }
  }
}
