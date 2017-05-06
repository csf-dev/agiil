using System;
using Autofac;

namespace Agiil.Web.Services.Auth
{
  public class AutofacOAuthApplicationConnection : IOAuthApplicationConnection, IDisposable
  {
    readonly ILifetimeScope scope;

    public OAuthAuthorizationChecker GetAuthChecker()
    {
      return scope.Resolve<OAuthAuthorizationChecker>();
    }

    #region IDisposable Support
    bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
      if(!disposedValue)
      {
        if(disposing)
        {
          scope.Dispose();
        }
        disposedValue = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
    }
    #endregion

    public AutofacOAuthApplicationConnection(ILifetimeScope parentScope)
    {
      if(parentScope == null)
        throw new ArgumentNullException(nameof(parentScope));

      this.scope = parentScope.BeginLifetimeScope(Autofac.Core.Lifetime.MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
    }
  }
}
