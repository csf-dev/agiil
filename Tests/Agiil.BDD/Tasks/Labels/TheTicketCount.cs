using System;
using System.Linq;
using Agiil.BDD.Models.Labels;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay.Selenium.Models;
using CSF.Screenplay.Selenium.Queries;

namespace Agiil.BDD.Tasks.Labels
{
  public class TheTicketCount : Question<int>
  {
    readonly string labelName;
    readonly bool includeOpenTickets, includeClosedTickets;

		protected override string GetReport(INamed actor)
		{
      string openClosed = null;

      if(includeOpenTickets && includeClosedTickets)
        openClosed = String.Empty;
      else if(includeOpenTickets)
        openClosed = " open";
      else if(includeClosedTickets)
        openClosed = " closed";

      return $"{actor.Name} gets the count of{openClosed} tickets for the label '{labelName}'";
		}

		protected override int PerformAs(IPerformer actor)
    {
      var labelElement = GetTheLabelElement(actor);

      int runningCount = 0;

      if(includeOpenTickets)
        runningCount += GetCountOfOpenTickets(actor, labelElement);
      
      if(includeClosedTickets)
        runningCount += GetCountOfClosedTickets(actor, labelElement);

      return runningCount;
    }

    IWebElementAdapter GetTheLabelElement(IPerformer actor)
    {
      var desiredLabelElement = actor.Perform(Elements
                                              .In(LabelList.TheLabelList)
                                              .ThatAre(LabelList.LabelItems)
                                              .That(IsTheCorrectLabel())
                                              .Called($"the '{labelName}' label"));

      if(desiredLabelElement.Elements.Count != 1)
        throw new MissingLabelException($"The label '{labelName}' was not found in the list");

      return desiredLabelElement.Elements.First();
    }

    int GetCountOfOpenTickets(IPerformer actor, IWebElementAdapter labelElement)
    {
      var theCount = actor.Perform(Elements.In(labelElement).ThatAre(LabelList.OpenTicketCount).Called("the count of open tickets"));
      return actor.Perform(TheText.From(theCount).As<int>());
    }

    int GetCountOfClosedTickets(IPerformer actor, IWebElementAdapter labelElement)
    {
      var theCount = actor.Perform(Elements.In(labelElement).ThatAre(LabelList.ClosedTicketCount).Called("the count of closed tickets"));
      return actor.Perform(TheText.From(theCount).As<int>());
    }

    CSF.Screenplay.Selenium.ElementMatching.IMatcher IsTheCorrectLabel()
    {
      return Matcher.Create(new TextQuery(),
                            text => text.StartsWith(labelName, StringComparison.InvariantCulture));
    }

    public TheTicketCount(string labelName, bool includeOpen, bool includeClosed)
    {
      if(labelName == null)
        throw new ArgumentNullException(nameof(labelName));
      if(!includeOpen && !includeClosed)
        throw new ArgumentException($"One of the parameters {nameof(includeOpen)} or {nameof(includeClosed)} must be true.");

      this.labelName = labelName;
      includeOpenTickets = includeOpen;
      includeClosedTickets = includeClosed;
    }

    public static GetTheTicketCountBuilder ForTheTheLabel(string name)
    {
      return new GetTheTicketCountBuilder(name);
    }

    public class GetTheTicketCountBuilder
    {
      string labelName;

      public Question<int> WhichAreOpen()
      {
        return new TheTicketCount(labelName, true, false);
      }

      public Question<int> WhichAreClosed()
      {
        return new TheTicketCount(labelName, false, true);
      }

      public Question<int> WhichAreOpenOrClosed()
      {
        return new TheTicketCount(labelName, true, true);
      }

      internal GetTheTicketCountBuilder(string name)
      {
        labelName = name;
      }
    }
  }
}
