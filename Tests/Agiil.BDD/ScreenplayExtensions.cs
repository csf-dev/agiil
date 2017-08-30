using System;
using Agiil.BDD.Abilities;
using CSF.Screenplay;
using CSF.Screenplay.Actors;

namespace Agiil.BDD
{
  public static class ScreenplayExtensions
  {
    public static IActor GetApril(this IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      var cast = screenplay.GetCast();
      return cast.Get("April", CustomiseApril);
    }

    public static IActor GetJoe(this IScreenplayScenario screenplay, string actorName)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      if(actorName == null)
        throw new ArgumentNullException(nameof(actorName));

      var cast = screenplay.GetCast();
      return cast.Get(actorName, CustomiseWebUser, screenplay);
    }

    static void CustomiseApril(IActor april)
    {
      april.HasAbility<ActAsTheApplication>();
    }

    static void CustomiseWebUser(IActor actor, IScreenplayScenario scenario)
    {
      var browseTheWeb = scenario.GetWebBrowser();
      actor.IsAbleTo(browseTheWeb);
    }
  }
}
