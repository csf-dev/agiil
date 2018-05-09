using System;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ChangeTheTicket
  {
    public static IPerformable TitleTo(string title) => new ChangeTheTicketTitle(title);

    public static IPerformable DescriptionTo(string description) => new ChangeTheTicketDescription(description);

    public static IPerformable LabelsTo(string newLabels) => new ChangeTheTicketLabels(newLabels);

    public static IPerformable SprintTo(string sprintTitle) => new ChangeTheTicketSprint(sprintTitle);

    public static IPerformable TypeTo(string type) => new ChangeTheTicketType(type);

    public static IPerformable StatusToClosed() => new CloseTheTicket();

    public static IPerformable StatusToReopened() => new ReopenTheTicket();
  }
}
