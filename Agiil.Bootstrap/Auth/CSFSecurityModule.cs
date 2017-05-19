using System;
using System.Reflection;
using Autofac;
using CSF.Security.Authentication;

namespace Agiil.Bootstrap.Auth
{
  public class CSFSecurityModule : NamespaceModule
  {
    protected override string Namespace => typeof(IPassword).Namespace;

    protected override System.Collections.Generic.IEnumerable<Type> TypesNotToRegisterAutomatically
    {
      get { return new [] { typeof(PBKDF2PasswordVerifier), }; }
    }

    protected override System.Collections.Generic.IEnumerable<System.Reflection.Assembly> GetSearchAssemblies()
    {
      return new [] { Assembly.GetAssembly(typeof(ICredentialsCreator)), };
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder
        .Register(ctx => new PBKDF2PasswordVerifier(iterationCount: 20000))
        .As<ICredentialsCreator>();
      
    }
  }
}
