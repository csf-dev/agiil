using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class TicketList : Page
  {
    public override string GetName() => "the ticket list page";

    public override IUriProvider GetUriProvider() => new AppUri("Tickets");

    public static ILocatorBasedTarget TicketsTitled(string title)
      => new XPath($"//table[@class='ticket_list']//td[@class='TicketTitle' and ./a='{title}']",
                   $"a ticket with the title '{title}'");

    public static ILocatorBasedTarget TicketLink
      => new CssSelector("a.TicketLink", "the open-ticket link");

    public static ILocatorBasedTarget AgiilQueryText
      => new ElementId("query_text", "the Agiil Query text");

    public static ILocatorBasedTarget PerformAgiilQueryButton
      => new CssSelector(".agiil_query .perform_search", "the perform search button");
  }
}
