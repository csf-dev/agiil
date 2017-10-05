using System;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public static class VerifyThatThereIsATicket
  {
    public static IPerformable WithTheTitle(string title)
      => new VerifyThatThereIsATicketTitled(title);
  }
}
