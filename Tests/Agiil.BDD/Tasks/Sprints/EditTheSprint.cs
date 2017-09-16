﻿using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Models.Sprints;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Sprints
{
  public class EditTheSprint : Performable
  {
    readonly SprintDetails spec;

    protected override string GetReport(INamed actor) => $"{actor.Name} makes the specified edits to the sprint";

    protected override void PerformAs(IPerformer actor)
    {
      if(spec.Title != null)
      {
        actor.Perform(Clear.TheContentsOf(EditSprint.SprintName));
        actor.Perform(Enter.TheText(spec.Title).Into(EditSprint.SprintName));
      }

      if(spec.Description != null)
      {
        actor.Perform(Clear.TheContentsOf(EditSprint.Description));
        actor.Perform(Enter.TheText(spec.Description).Into(EditSprint.Description));
      }

      if(spec.StartDate.HasValue)
      {
        var date = spec.StartDate.Value.ToString("dd/MM/yyyy");
        actor.Perform(Enter.TheText(date).Into(EditSprint.StartDate));
      }

      if(spec.EndDate.HasValue)
      {
        var date = spec.EndDate.Value.ToString("dd/MM/yyyy");
        actor.Perform(Enter.TheText(date).Into(EditSprint.EndDate));
      }

      actor.Perform(Click.On(EditSprint.SubmitButton));
    }

    EditTheSprint(SprintDetails spec)
    {
      if(spec == null)
        throw new ArgumentNullException(nameof(spec));
      this.spec = spec;
    }

    public static IPerformable UsingTheSpecification(SprintDetails spec)
      => new EditTheSprint(spec);
  }
}
