using System;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public static class OpenTheTicket
  {
    public static IPerformable Titled(string title) => new OpenTicketDetailByTitle(title);

    public static IPerformable ForEditingByTitle(string title)
      => new OpenTicketForEditingByTitle(title);
  }
}
