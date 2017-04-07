using System;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Agiil.Web.Bootstrap
{
  public class OwinCompatibleLifetimeScopeProvider : RequestLifetimeScopeProvider, ILifetimeScopeProvider
  {
    public new void EndLifetimeScope()
    {
      if(HttpContext.Current != null)
      {
        base.EndLifetimeScope();
      }
    }

    void ILifetimeScopeProvider.EndLifetimeScope()
    {
      this.EndLifetimeScope();
    }

    public OwinCompatibleLifetimeScopeProvider(ILifetimeScope scope) : base(scope) {}
  }
}
