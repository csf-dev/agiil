﻿using System;
using System.Web;
using Autofac;
using Autofac.Core;
using CSF.IssueTracker.Auth;
using CSF.Security;

namespace CSF.IssueTracker.Bootstrap.Auth
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
        .As<CSF.IssueTracker.Auth.IAuthenticationService>();

      builder
        .RegisterType<Base64KeyAndSaltConverter>()
        .As<IKeyAndSaltConverter>();

      builder
        .Register((context, parameters) => {
          var username = parameters.Named<string>("username");
          var password = parameters.Named<string>("password");

          var credentials = new LoginCredentials(username, password);

          return new LoginRequest(credentials);
        })
        .As<ILoginRequest>();

      builder.Register((context, parameters) => HttpContext.Current.GetOwinContext().Authentication);

    }
  }
}
