using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Labels
{
  public class EnterTheLabels : Performable
  {
    readonly string labels;

    protected override string GetReport(INamed actor)
    => $"{actor.Name} enters the labels {labels}";

    protected override void PerformAs(IPerformer actor)
    {
      if(String.IsNullOrWhiteSpace(labels)) return;

      actor.Perform(Wait.ForAtMost(1).Seconds().OrUntil(EditTicket.TicketLabelsInputBox).IsVisible());

      var labelNames = labels.Split(',');
      foreach(var name in labelNames)
      {
        actor.Perform(EnterALabel.Named(name));
      }
    }

    public EnterTheLabels(string labels)
    {
      if(labels == null)
        throw new ArgumentNullException(nameof(labels));
      this.labels = labels;
    }

    public static IPerformable Named(string labels)
    => new EnterALabel(labels);
  }
}
