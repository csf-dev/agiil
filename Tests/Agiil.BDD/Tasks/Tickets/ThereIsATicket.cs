using System;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public static class ThereIsATicket
  {
    public static IQuestion<bool> WithTheTitle(string title) => new FindATicketByTitle(title);
  }
}
