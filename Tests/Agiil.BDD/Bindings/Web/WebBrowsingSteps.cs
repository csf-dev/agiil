using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Web.Abilities;
using CSF.WebDriverFactory;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Web
{
  [Binding]
  public class WebBrowsingSteps
  {
    readonly ICast cast;
    readonly IWebDriverFactory webDriverFactory;

    [Given("([A-Za-z0-9_-]+) can browse the web")]
    public void GivenTheyCanBrowseTheWeb(string username)
    {
      var webDriver = webDriverFactory.GetWebDriver();
      var browseTheWeb = new BrowseTheWeb(webDriver);

      cast.GetActor(username).IsAbleTo(browseTheWeb);
    }

    public WebBrowsingSteps(ICast cast, IWebDriverFactory webDriverFactory)
    {
      if(webDriverFactory == null)
        throw new ArgumentNullException(nameof(webDriverFactory));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
      this.webDriverFactory = webDriverFactory;
    }
  }
}
