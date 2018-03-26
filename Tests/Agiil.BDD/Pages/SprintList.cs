using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class SprintList : Page
  {
    readonly bool showClosedSprints;

    public override string GetName() => "the sprint listing page";

    public override IUriProvider GetUriProvider() => new AppUri(GetUriString());

    public static ILocatorBasedTarget SprintListTable => new ClassName("sprint_list", "the list of sprints");

    public static ILocatorBasedTarget SprintNames => new CssSelector(".sprint_list .sprint_name",
                                                                     "the names of the displayed sprints");

    public static ILocatorBasedTarget TheSprintNamed(string name)
    {
      var xpath = $@"//table[@class='sprint_list']/tbody/tr/td/a[@class = 'sprint_name' and text() = '{name}']";
      return new XPath(xpath, $"the sprint-details link for {name}");
    }


    public static ILocatorBasedTarget SprintStartDate(string sprintName)
    {
      var xpath = $@"//table[@class='sprint_list']/tbody/tr[td/a[@class = 'sprint_name'] = '{sprintName}']/td/span[@class = 'sprint_start_date']";
      return new XPath(xpath, $"the start date for {sprintName}");
    }

    public static ILocatorBasedTarget SprintEndDate(string sprintName)
    {
      var xpath = $@"//table[@class='sprint_list']/tbody/tr[td/a[@class = 'sprint_name'] = '{sprintName}']/td/span[@class = 'sprint_end_date']";
      return new XPath(xpath, $"the end date for {sprintName}");
    }

    string GetUriString()
    {
      if(showClosedSprints)
        return "Sprints?ShowClosedSprints=True";

      return "Sprints";
    }

    SprintList(bool showClosedSprints = false)
    {
      this.showClosedSprints = showClosedSprints;
    }

    public static SprintList ForOpenSprints() => new SprintList(false);

    public static SprintList ForClosedSprints() => new SprintList(true);
  }
}
