using System;
using System.Collections.Generic;

namespace Agiil.Domain.Tickets
{
  public interface IGetsAvailableRelationships
  {
    IReadOnlyList<AvailableRelationship> GetAvailableRelationships();
  }
}
