using System;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public static class VerifyThatThereIsNotATicket
  {
    public static IPerformable WithTheTitle(string title)
      => new VerifyThatThereIsNotATicketTitled(title);
  }
}
