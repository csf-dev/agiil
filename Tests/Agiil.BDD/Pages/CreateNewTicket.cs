using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.Pages
{
  public class CreateNewTicket : Page
  {
    public override string GetName() => "the create-ticket page";

    public override IUriProvider GetUriProvider() => new AppUri("NewTicket");

    public static ILocatorBasedTarget CreationSuccessMessage = new CssSelector("#ticket_creation_success_feedback",
                                                                               "a ticket-creation success message");

    public static ILocatorBasedTarget CreationFailureMessage = new CssSelector("#ticket_creation_failure_feedback",
                                                                               "a ticket-creation failure message");
  }
}
