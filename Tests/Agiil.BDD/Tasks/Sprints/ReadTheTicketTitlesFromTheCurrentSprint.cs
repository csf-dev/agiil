using System;
using System.Collections.Generic;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Sprints
{
  public class ReadTheTicketTitlesFromTheCurrentSprint : Question<IReadOnlyList<string>>
  {
    readonly bool openTickets;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} reads the titles of the {StateDescription} tickets in the current sprint";

    string StateDescription => openTickets? "open" : "closed";

    protected override IReadOnlyList<string> PerformAs(IPerformer actor)
    {
      var ticketTitles = openTickets? SprintDetail.OpenTicketTitles : SprintDetail.ClosedTicketTitles;
      return actor.Perform(TheText.OfAll(ticketTitles));
    }

    public ReadTheTicketTitlesFromTheCurrentSprint(bool openTickets)
    {
      this.openTickets = openTickets;
    }

    public static IQuestion<IReadOnlyList<string>> WhichAre(string openOrClosed)
    {
      bool open = (openOrClosed == "open");
      return new ReadTheTicketTitlesFromTheCurrentSprint(open);
    }

    public static IQuestion<IReadOnlyList<string>> WhichAreOpen()
      => new ReadTheTicketTitlesFromTheCurrentSprint(true);

    public static IQuestion<IReadOnlyList<string>> WhichAreClosed()
      => new ReadTheTicketTitlesFromTheCurrentSprint(false);
  }
}
