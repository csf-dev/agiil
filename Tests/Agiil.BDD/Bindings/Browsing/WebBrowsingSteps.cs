using System;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;
using Agiil.BDD.Tasks.Browsing;
using Agiil.BDD.Actions;
using Agiil.BDD.Tasks.App;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Auth;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Abilities;
using CSF.Screenplay.WebApis.Abilities;
using Agiil.BDD.Abilities;
using CSF.FlexDi;
using Agiil.BDD.Bindings.Actors;
using Agiil.BDD.Bindings.App;
using Agiil.BDD.Bindings.Auth;
using CSF.Screenplay;

namespace Agiil.BDD.Bindings.Browsing
{
  [Binding]
  public class WebBrowsingSteps
  {
    readonly ICast cast;
    readonly IResolvesServices resolver;

    [Given(@"Joe is on on the application home page")]
    public void GivenJoeIsLookingAtTheAppHomePage()
    {
      // Currently bugged due to https://github.com/csf-dev/CSF.Screenplay/issues/126
      //testRunner.Value.Given("Joe can browse the web");
      resolver.Resolve<JoeSteps>().GivenJoeCanBrowseTheWeb();

      var joe = cast.Get<Joe>();
      Given(joe).WasAbleTo<VisitTheHomePage>();
    }

    [Given(@"Youssef is logged into a fresh installation of the site")]
    public void GivenYoussefIsLoggedIntoAFreshlyInstalledSite()
    {
      // Currently bugged due to https://github.com/csf-dev/CSF.Screenplay/issues/126
      //testRunner.Value.Given("Agiil has just been installed");
      //testRunner.Value.Given("Youssef has a user account");
      //testRunner.Value.Given("Youssef can browse the web");
      resolver.Resolve<InstallationSteps>().GivenAgiilHasJustBeenInstalled();
      resolver.Resolve<UserAccountSteps>().GivenYoussefHasAUserAccount();
      resolver.Resolve<YoussefSteps>().GivenYoussefCanBrowseTheWeb();

      var youssef = cast.Get<Youssef>();
      Given(youssef).WasAbleTo<LogInWithTheirAccount>();
    }

    [Given(@"Youssef is logged into a fresh installation of the site containing the simple sample project")]
    public void GivenYoussefIsLoggedIntoAFreshlyInstalledSiteWithSimpleSampleData()
    {
      // Currently bugged due to https://github.com/csf-dev/CSF.Screenplay/issues/126
      //testRunner.Value.Given("Agiil has just been installed");
      //testRunner.Value.Given("April has set up the simple sample project");
      //testRunner.Value.Given("Youssef has a user account");
      //testRunner.Value.Given("Youssef can browse the web");
      resolver.Resolve<InstallationSteps>().GivenAgiilHasJustBeenInstalled();
      resolver.Resolve<ProjectSetupSteps>().GivenAprilHasSetUpTheSimpleSampleProject();
      resolver.Resolve<UserAccountSteps>().GivenYoussefHasAUserAccount();
      resolver.Resolve<YoussefSteps>().GivenYoussefCanBrowseTheWeb();

      var youssef = cast.Get<Youssef>();
      Given(youssef).WasAbleTo<LogInWithTheirAccount>();
    }

    public WebBrowsingSteps(ICast cast,
                            IResolvesServices resolver)
    {
      this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
      this.cast = cast ?? throw new ArgumentNullException(nameof(cast));
    }
  }
}
