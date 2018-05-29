using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay.Selenium.Models;
using CSF.Screenplay.Selenium.Queries;

namespace Agiil.BDD.Tasks.Tickets
{
  public class FollowALinkFromTheTicketDescription : Performable
  {
    static readonly ILocatorBasedTarget Hyperlinks = new CssSelector("a", "hyperlinks");

    readonly string linkText;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} clicks on a link in the ticket description which has reads '{linkText}'";

    protected override void PerformAs(IPerformer actor)
    {
      var theLink = GetHyperlink(actor);
      actor.Perform(Navigate.ToAnotherPageByClicking(theLink));
    }

    ElementCollection GetHyperlink(IPerformer actor)
    {
      var haveTheSpecifiedText = Matcher.Create(new TextQuery(), x => x == linkText);
      var theLink = actor.Perform(Elements.In(TicketDetail.DescriptionContent)
                                          .ThatAre(Hyperlinks)
                                          .That(haveTheSpecifiedText)
                                          .Called("the chosen hyperlink"));
      return theLink;
    }

    public FollowALinkFromTheTicketDescription(string linkText)
    {
      if(linkText == null)
        throw new ArgumentNullException(nameof(linkText));
      this.linkText = linkText;
    }

    public static IPerformable WithTheText(string linkText) => new FollowALinkFromTheTicketDescription(linkText);
  }
}
