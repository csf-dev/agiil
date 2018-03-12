using System;
using Agiil.BDD.Personas;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Abilities;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Actors
{
  [Binding]
  public class JoeSteps
  {
    readonly ICast cast;
    readonly BrowseTheWeb browseTheWeb;

    [Given("Joe can browse the web")]
    public void GivenJoeCanBrowseTheWeb()
    {
      var joe = cast.Get<Joe>();

      if(joe.HasAbility<BrowseTheWeb>()) return;

      joe.IsAbleTo(browseTheWeb);
    }

    public JoeSteps(ICast cast,
                    BrowseTheWeb browseTheWeb)
    {
      if(browseTheWeb == null)
        throw new ArgumentNullException(nameof(browseTheWeb));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
      this.browseTheWeb = browseTheWeb;
    }
  }
}
