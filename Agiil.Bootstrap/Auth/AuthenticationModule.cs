using System;
using System.Web;
using Autofac;
using Agiil.Auth;
using CSF.Security;
using Microsoft.Owin.Security;

namespace Agiil.Bootstrap.Auth
{
  public class AuthenticationModule : Module
  {
    protected override void Load (ContainerBuilder builder)
    {
      builder
        .RegisterType<PBKDF2CredentialVerifier<LoginCredentials,IStoredCredentialsWithKeyAndSalt>>()
        .As<ICredentialVerifier<LoginCredentials,IStoredCredentialsWithKeyAndSalt>>();

      builder
        .RegisterType<UserCredentialsRepository>()
        .As<ICredentialsRepository<LoginCredentials,IStoredCredentialsWithKeyAndSalt>>();

      builder
        .RegisterType<AuthenticationService<LoginCredentials,IStoredCredentialsWithKeyAndSalt>>()
        .As<IAuthenticationService<LoginCredentials>>();

      builder
        .RegisterType<Base64KeyAndSaltConverter>()
        .As<IKeyAndSaltConverter>();

      builder
        .Register((context, parameters) => {
          var username = parameters.Named<string>("username");
          var password = parameters.Named<string>("password");

        var credentials = new LoginCredentials { Username = username, Password = password };

          return new LoginRequest(credentials);
        })
        .As<ILoginRequest>();

      builder.RegisterType<ClaimsIdentityReader>().As<IIdentityReader>();

      builder.RegisterType<LoginLogoutManager>().As<ILoginLogoutManager>();

      builder
        .Register((context, parameters) => HttpContext.Current.GetOwinContext().Authentication)
        .As<IAuthenticationManager>();

    }
  }
}
