using System;
using Agiil.BDD.Abilities;
using CSF.FlexDi;
using CSF.Screenplay;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.Personas
{
  public class Ingrid : Persona
  {
    public override string Name => "Ingrid";

		public override void GrantAbilities(ICanReceiveAbilities actor, IResolvesServices resolver)
		{
      var resolveComponents = resolver.Resolve<ResolveComponentsFromAutofac>();
      actor.IsAbleTo(resolveComponents);
		}
	}
}
