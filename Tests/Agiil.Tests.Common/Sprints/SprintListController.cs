using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Agiil.Web.Controllers;
using Agiil.Web.Models.Sprints;
using NUnit.Framework;

namespace Agiil.Tests.Sprints
{
  public class SprintListController : ISprintListController
  {
    readonly SprintListModelContext context;
    readonly Lazy<SprintsController> webController;

    public void VisitSprintListControllerAndStoreListInContext()
    {
      var result = (ViewResult) webController.Value.Index(null);
      var model = (ListSprintModel) result.Model;

      context.Model = model;
    }

    public void AssertThatSprintListMatchesExpected(IList<SprintSummaryDto> expected)
    {
      var actual = context.Model.Sprints;
      CollectionAssert.AreEqual(expected, actual, new SprintSummaryDtoComparer());
    }

    public SprintListController(SprintListModelContext context,
                                Lazy<SprintsController> webController)
    {
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));
      if(context == null)
        throw new ArgumentNullException(nameof(context));
      this.webController = webController;
      this.context = context;
    }
  }
}
