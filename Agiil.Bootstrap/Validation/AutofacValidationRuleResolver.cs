using System;
using Autofac;
using CSF.Validation.Manifest;
using CSF.Validation.Rules;

namespace Agiil.Bootstrap.Validation
{
  public class AutofacValidationRuleResolver : IRuleResolver
  {
    readonly ILifetimeScope scope;

    public IRule Resolve(IManifestRule manifest)
    {
      if(manifest == null)
        throw new ArgumentNullException(nameof(manifest));

      var resolved = scope.Resolve(manifest.RuleType);
      return (IRule) resolved;
    }

    public AutofacValidationRuleResolver(ILifetimeScope scope)
    {
      if(scope == null)
        throw new ArgumentNullException(nameof(scope));
      this.scope = scope;
    }
  }
}
