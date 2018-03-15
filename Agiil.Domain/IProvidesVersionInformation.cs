using System;
using System.Collections.Generic;

namespace Agiil.Domain
{
  public interface IProvidesVersionInformation
  {
    string GetHumanReadableProductVersion();

    IReadOnlyCollection<ComponentVersionInfo> GetComponentVersions();
  }
}
