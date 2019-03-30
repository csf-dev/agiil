using System;
using Autofac;
using CSF.Screenplay.Abilities;

namespace Agiil.BDD.Abilities
{
  public class ResolveComponentsFromAutofac : Ability
  {
    readonly IContainer container;

    public TService ResolveFromContainer<TService>()
      => container.Resolve<TService>();

    public ILifetimeScope BeginHttpRequestScope()
      => container.BeginLifetimeScope(Autofac.Core.Lifetime.MatchingScopeLifetimeTags.RequestLifetimeScopeTag);

    public ResolveComponentsFromAutofac(IContainer container)
    {
      if(container == null)
        throw new ArgumentNullException(nameof(container));
      this.container = container;
    }
  }
}
