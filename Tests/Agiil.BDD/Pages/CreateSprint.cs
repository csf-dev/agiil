using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class CreateSprint : Page
  {
    public override string GetName() => "the Create Sprint page";

    public override IUriProvider GetUriProvider() => new AppUri("NewSprint");

    public static ILocatorBasedTarget Name => new ElementId("Name", "the sprint name");

    public static ILocatorBasedTarget StartDate => new ElementId("StartDate", "the start date");

    public static ILocatorBasedTarget EndDate => new ElementId("EndDate", "the end date");

    public static ILocatorBasedTarget SubmitButton => new ElementId("Submit", "the submit button");


    public static ILocatorBasedTarget FailureMessage => new ElementId("FailureMessage", "the failure message");
  }
}
