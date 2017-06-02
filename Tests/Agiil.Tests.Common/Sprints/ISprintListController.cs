using System;
using System.Collections.Generic;
using Agiil.Web.Models.Sprints;

namespace Agiil.Tests.Sprints
{
  public interface ISprintListController
  {
    void VisitSprintListControllerAndStoreListInContext();

    void AssertThatSprintListMatchesExpected(IList<SprintSummaryDto> expected);
  }
}
