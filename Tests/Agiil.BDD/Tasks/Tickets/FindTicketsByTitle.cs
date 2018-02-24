using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Tasks.Tickets
{
  public class FindTicketsByTitle : Question<ElementCollection>
  {
    readonly string title;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} finds tickets with the title '{title}'";

    protected override ElementCollection PerformAs(IPerformer actor)
    {
      return actor.Perform(Elements.InThePageBody()
                           .ThatAre(TicketList.TicketsTitled(title))
                           .Called($"the tickets titled {title}"));
    }

    public FindTicketsByTitle(string title)
    {
      if(title == null)
        throw new ArgumentNullException(nameof(title));
      this.title = title;
    }
  }
}
