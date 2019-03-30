using System;
using Autofac;
using CSF.Security.Authentication;

namespace Agiil.Bootstrap.Auth
{
  public class CsfSecurityModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder
        .Register(ctx => new PBKDF2PasswordVerifier(iterationCount: 20000))
        .As<ICredentialsCreator>();
      
    }
  }
}
