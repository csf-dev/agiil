using System;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.Tasks.Tickets
{
  public static class FindTickets
  {
    public static IQuestion<ElementCollection> WithTheTitle(string title)
      => new FindTicketsByTitle(title);
  }
}
