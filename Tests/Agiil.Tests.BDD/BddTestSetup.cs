using System;
using NUnit.Framework;
using CSF.Screenplay.NUnit;
using CSF.Screenplay.Web.Abilities;
using CSF.Screenplay.Reporting;
using CSF.Screenplay.Actors;

[assembly: ScreenplayTest]

namespace Agiil.Tests.BDD
{
  [SetUpFixture]
  public class BddTestSetup
  {
    [OneTimeSetUp]
    public void BeforeAnyTests()
    {
      Stage.UriTransformer = new RootUriPrependingTransformer("http://localhost:8080/");
      Stage.Reporter = new TextReporter(TestContext.Out);
      Stage.Cast.NewActorCallback = ConfigureDefaultActor;
    }

    [OneTimeTearDown]
    public void OnetimeTeardown()
    {
      Stage.DisposeCurrentWebDriver();
      Stage.Reporter.CompleteTestRun();
      TestContext.Out.Flush();
    }

    void ConfigureDefaultActor(IActor actor)
    {
      Stage.Reporter.Subscribe(actor);

      var browseTheWeb = Stage.GetDefaultWebBrowsingAbility();
      actor.IsAbleTo(browseTheWeb);
    }
  }
}

