using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class LabelList : Page
  {
    public override string GetName() => "the list of labels page";

    public override IUriProvider GetUriProvider() => new AppUri("Labels");

    public static ILocatorBasedTarget TheLabelList => new CssSelector("#LabelList", "the label list");

    public static ILocatorBasedTarget LabelItems => new CssSelector("#LabelList li", "labels");

    public static ILocatorBasedTarget LabelNames => new CssSelector("#LabelList .Name", "label names");

    public static ILocatorBasedTarget OpenTicketCount => new CssSelector(".OpenTickets", "the count of open tickets");

    public static ILocatorBasedTarget ClosedTicketCount => new CssSelector(".ClosedTickets", "the count of closed tickets");
  }
}
