using System;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public static class TheTicket
  {
    public static IQuestion<string> Description() => new ReadTheTicketDescription();

    public static IQuestion<string> SprintTitle() => new ReadTheTicketSprintTitle();
  }
}
