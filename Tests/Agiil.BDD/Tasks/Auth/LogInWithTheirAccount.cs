using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Tasks.Browsing;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Auth
{
  public class LogInWithTheirAccount : Performable
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} gets logged into the site with their account.";

    protected override void PerformAs(IPerformer actor)
    {
      var loginAbility = actor.GetAbility<LogInWithAUserAccount>();

      actor.Perform<VisitTheHomePage>();
      actor.Perform(LogIntoTheSite.As(loginAbility.Username).WithThePassword(loginAbility.Password));
    }
  }
}
