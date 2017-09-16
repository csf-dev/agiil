using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.Pages
{
  public class SprintDetail : Page
  {
    readonly long sprintId;

    public override string GetName() => "the sprint detail page";

    public override IUriProvider GetUriProvider() => new AppUri($"Sprint/{sprintId}");

    SprintDetail(long sprintId)
    {
      this.sprintId = sprintId;
    }

    public static Page ForSprintId(long id) => new SprintDetail(id);

    public static ILocatorBasedTarget SprintName => new ElementId("SprintName", $"the sprint name");

    public static ILocatorBasedTarget StartDate => new ElementId("SprintStartDate", $"the sprint start date");

    public static ILocatorBasedTarget EndDate => new ElementId("SprintEndDate", $"the sprint end date");

    public static ILocatorBasedTarget Description
      => new CssSelector("section.description .description_content", $"the sprint description");

    public static ILocatorBasedTarget EditLink => new ElementId("EditSprintLink", $"the edit sprint link");


  }
}
