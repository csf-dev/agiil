using System;
using Agiil.BDD.Personas;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using CSF.Screenplay.WebApis.Abilities;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Actors
{
  [Binding]
  public class AprilSteps
  {
    readonly ICast cast;
    readonly ConsumeWebServices actAsTheApplication;

    [Given(@"April can act as the application")]
    public void GivenAprilCanActAsTheApplication()
    {
      var april = cast.Get<April>();

      if(april.HasAbility<ConsumeWebServices>()) return;

      april.IsAbleTo(actAsTheApplication);
    }

    public AprilSteps(ICast cast, ConsumeWebServices actAsTheApplication)
    {
      if(actAsTheApplication == null)
        throw new ArgumentNullException(nameof(actAsTheApplication));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.actAsTheApplication = actAsTheApplication;
      this.cast = cast;
    }
  }
}
