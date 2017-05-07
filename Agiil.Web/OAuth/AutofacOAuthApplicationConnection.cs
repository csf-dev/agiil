using System;
using Autofac;

namespace Agiil.Web.OAuth
{
  public class AutofacOAuthApplicationConnection : IOAuthApplicationConnection, IDisposable
  {
    readonly ILifetimeScope scope;

    public IOAuthAuthorizationChecker GetAuthChecker()
    {
      return scope.Resolve<IOAuthAuthorizationChecker>();
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
