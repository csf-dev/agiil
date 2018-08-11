using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class PerformAnAgiilQuery : Performable
  {
    readonly string queryText;

		protected override string GetReport(INamed actor)
      => $"{actor.Name} performs the Agiil Query {queryText}";

		protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Clear.TheContentsOf(TicketList.AgiilQueryText));
      actor.Perform(Enter.TheText(queryText).Into(TicketList.AgiilQueryText));
      actor.Perform(Navigate.ToAnotherPageByClicking(TicketList.PerformAgiilQueryButton));
    }

    public PerformAnAgiilQuery(string queryText)
    {
      if(queryText == null)
        throw new ArgumentNullException(nameof(queryText));
      this.queryText = queryText;
    }

    public static IPerformable WithTheText(string queryText) => new PerformAnAgiilQuery(queryText);
  }
}
