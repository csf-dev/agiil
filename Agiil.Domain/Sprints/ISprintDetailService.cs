using System;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
  public interface ISprintDetailService
  {
    Sprint GetSprint(IIdentity<Sprint> identity);
  }
}
