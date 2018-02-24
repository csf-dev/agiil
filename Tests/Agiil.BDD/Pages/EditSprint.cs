using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class EditSprint : Page
  {
    long sprintId;

    public override string GetName() => "the edit sprint page";

    public override IUriProvider GetUriProvider() => new AppUri($"Sprint/Edit/{sprintId}");

    EditSprint(long sprintId)
    {
      this.sprintId = sprintId;
    }

    public static Page WithId(long id) => new EditSprint(id);

    public static ILocatorBasedTarget SprintName => new ElementId("Name", $"the sprint name");

    public static ILocatorBasedTarget StartDate => new ElementId("StartDate", $"the sprint start date");

    public static ILocatorBasedTarget EndDate => new ElementId("EndDate", $"the sprint end date");

    public static ILocatorBasedTarget Description
      => new ElementId("Description", $"the sprint description");

    public static ILocatorBasedTarget SubmitButton => new ElementId("Submit", $"the submit button");

    public static ILocatorBasedTarget EditFailureMessage => new ElementId("EditFailureMessage", $"the editing-failure message");
  }
}
