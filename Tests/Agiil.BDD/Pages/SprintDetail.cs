using System;
using CSF.Screenplay.Selenium.Models;

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

    public static ILocatorBasedTarget OpenTicketTitles
      => new CssSelector(".contained_tickets .open_tickets .ticket .title", "the titles of the open tickets in this sprint");

    public static ILocatorBasedTarget ClosedTicketTitles
    => new CssSelector(".contained_tickets .closed_tickets .ticket .title", "the titles of the closed tickets in this sprint");

  }
}
