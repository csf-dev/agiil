using System;
using Agiil.BDD.Personas;
using CSF.Screenplay.Actors;
using CSF.Screenplay.JsonApis.Abilities;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Bindings.Actors
{
  [Binding]
  public class AprilSteps
  {
    readonly ICast cast;
    readonly ConsumeJsonWebServices actAsTheApplication;

    [Given(@"April can act as the application")]
    public void GivenAprilCanActAsTheApplication()
    {
      var april = cast.Get<April>();

      if(april.HasAbility<ConsumeJsonWebServices>()) return;

      april.IsAbleTo(actAsTheApplication);
    }

    public AprilSteps(ICast cast, ConsumeJsonWebServices actAsTheApplication)
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
