using System;
namespace Agiil.Domain
{
  public interface IEnvironment
  {
    DateTime GetCurrentUtcTimestamp();

    DateTime GetCurrentLocalTimestamp();
  }
}
