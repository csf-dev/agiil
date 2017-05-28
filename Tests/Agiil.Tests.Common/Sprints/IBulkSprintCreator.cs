using System;
using System.Collections.Generic;

namespace Agiil.Tests.Sprints
{
  public interface IBulkSprintCreator
  {
    void Create(IEnumerable<BulkSprintCreationSpecification> sprints);
  }
}
