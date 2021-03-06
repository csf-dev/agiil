﻿using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Models.Sprints;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Sprints
{
  public class CreateASprint : Performable
  {
    readonly SprintDetails details;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} creates a sprint with supplied details";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Clear.TheContentsOf(CreateSprint.Name));

      if(details.Title != null)
        actor.Perform(Enter.TheText(details.Title).Into(CreateSprint.Name));
        
      if(details.StartDate.HasValue)
        actor.Perform(Enter.TheDate(details.StartDate.Value).Into(CreateSprint.StartDate));

      if(details.EndDate.HasValue)
        actor.Perform(Enter.TheDate(details.EndDate.Value).Into(CreateSprint.EndDate));

      actor.Perform(Navigate.ToAnotherPageByClicking(CreateSprint.SubmitButton));
    }

    CreateASprint(SprintDetails details)
    {
      if(details == null)
        throw new ArgumentNullException(nameof(details));
      this.details = details;
    }

    public static IPerformable WithTheDetails(SprintDetails details)
      => new CreateASprint(details);
  }
}
