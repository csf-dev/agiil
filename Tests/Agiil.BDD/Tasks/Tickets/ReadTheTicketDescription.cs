﻿using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ReadTheTicketTitle : Question<string>
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} reads the ticket title";

    protected override string PerformAs(IPerformer actor)
    {
      return actor.Perform(TheText.Of(TicketDetail.TitleContent));
    }
  }
}
