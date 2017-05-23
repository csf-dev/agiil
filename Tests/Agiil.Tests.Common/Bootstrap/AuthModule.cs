using System;
using Autofac;
using Agiil.Tests.Auth;
using Agiil.Auth;
using System.Reflection;

namespace Agiil.Tests.Bootstrap
{
  public class AuthModule : Agiil.Bootstrap.NamespaceModule
  {
    protected override string Namespace => typeof(IChangePasswordController).Namespace;

    protected override System.Collections.Generic.IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] { Assembly.GetExecutingAssembly() };
    }
  }
}
