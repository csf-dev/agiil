using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using OpenQA.Selenium;

namespace Agiil.BDD.Tasks.Labels
{
  public class EnterALabel : Performable
  {
    readonly string label;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} enters the label {label}";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Type.TheText(label.Trim()).Into(EditTicket.TicketLabelsInputBox));
      actor.Perform(Enter.TheText(Keys.Enter).Into(EditTicket.TicketLabelsInputBox));
    }

    public EnterALabel(string label)
    {
      if(label == null)
        throw new ArgumentNullException(nameof(label));
      this.label = label;
    }

    public static IPerformable Named(string label)
      => new EnterALabel(label);
  }
}
