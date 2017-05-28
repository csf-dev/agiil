using System;
using System.Collections.Generic;

namespace Agiil.Domain.Sprints
{
  public interface ISprintLister
  {
    IList<Sprint> GetSprints();
  }
}
