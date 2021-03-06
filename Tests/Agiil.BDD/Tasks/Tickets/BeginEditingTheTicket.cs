﻿using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class BeginEditingTheTicket : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} begins editing the ticket";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Navigate.ToAnotherPageByClicking(TicketDetail.EditTicketLink));
      actor.Perform(Wait.Until(EditTicket.EditTicketForm).IsVisible());
    }
  }
}
