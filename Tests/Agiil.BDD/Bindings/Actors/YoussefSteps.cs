using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Personas;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Abilities;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Actors
{
  [Binding]
  public class YoussefSteps
  {
    readonly ICast cast;
    readonly BrowseTheWeb browseTheWeb;
    readonly Lazy<ITestRunner> testRunner;

    [Given(@"Youssef can browse the web")]
    public void GivenYoussefCanBrowseTheWeb()
    {
      var youssef = cast.Get<Youssef>();

      if(youssef.HasAbility<BrowseTheWeb>()) return;

      youssef.IsAbleTo(browseTheWeb);
    }

    [Given(@"Youssef can log in with his username and password")]
    public void GivenYoussefCanLogInWithAUsernameAndPassword()
    {
      var youssef = cast.Get<Youssef>();

      if(youssef.HasAbility<LogInWithAUserAccount>()) return;

      youssef.IsAbleTo(LogInWithAUserAccount.WithTheUsername(Youssef.Username).AndThePassword(Youssef.Password));
    }

    public YoussefSteps(ICast cast,
                        BrowseTheWeb browseTheWeb,
                        Lazy<ITestRunner> testRunner)
    {
      if(testRunner == null)
        throw new ArgumentNullException(nameof(testRunner));
      if(browseTheWeb == null)
        throw new ArgumentNullException(nameof(browseTheWeb));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
      this.browseTheWeb = browseTheWeb;
      this.testRunner = testRunner;
    }
  }
}
