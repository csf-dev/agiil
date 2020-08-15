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
                            BrowseTheWeb browseTheWeb)
        {
            this.cast = cast ?? throw new ArgumentNullException(nameof(cast));
            this.browseTheWeb = browseTheWeb ?? throw new ArgumentNullException(nameof(browseTheWeb));
        }
    }
}
