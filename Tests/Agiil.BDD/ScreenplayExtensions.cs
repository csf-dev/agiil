using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Personas;
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
      return cast.Get(April.Name, CustomiseApril);
    }

    public static IActor GetJoe(this IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      
      var cast = screenplay.GetCast();
      return cast.Get(Joe.Name, CustomiseJoe, screenplay);
    }

    public static IActor GetYoussef(this IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      var cast = screenplay.GetCast();
      return cast.Get(Youssef.Name, CustomiseYoussef, screenplay);
    }

    static void CustomiseApril(IActor april)
    {
      april.HasAbility<ActAsTheApplication>();
    }

    static void CustomiseJoe(IActor joe, IScreenplayScenario scenario)
    {
      var browseTheWeb = scenario.GetWebBrowser();
      joe.IsAbleTo(browseTheWeb);
    }

    static void CustomiseYoussef(IActor youssef, IScreenplayScenario scenario)
    {
      var browseTheWeb = scenario.GetWebBrowser();
      youssef.IsAbleTo(browseTheWeb);
      youssef.IsAbleTo(LogInWithAUserAccount.WithTheUsername(Youssef.Name).AndThePassword(Youssef.Password));
    }
  }
}
