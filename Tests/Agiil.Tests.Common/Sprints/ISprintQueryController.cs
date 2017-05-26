using System;
namespace Agiil.Tests.Sprints
{
  public interface ISprintQueryController
  {
    bool DoesSprintExist(SprintSearchCriteria criteria = null);
  }
}
