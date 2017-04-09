using System;
using System.Web;
using Autofac;
using Agiil.Auth;
using CSF.Security.Authentication;
using Microsoft.Owin.Security;
using Agiil.Domain.Auth;

namespace Agiil.Bootstrap.Auth
{
  public class AuthenticationModule : Module
  {
    protected override void Load (ContainerBuilder builder)
    {
      builder
        .Register(ctx => {
          var repo = ctx.Resolve<IStoredCredentialsRepository>();
          return new AuthenticationService(repo);
        })
        .As<IPasswordAuthenticationService>();

      builder
        .RegisterType<UserCredentialsRepository>()
        .As<IStoredCredentialsRepository>();

      builder
        .Register((context, parameters) => {
          var username = parameters.Named<string>("username");
          var password = parameters.Named<string>("password");

        var credentials = new LoginCredentials { Username = username, Password = password };

          return new LoginRequest(credentials);
        })
        .As<ILoginRequest>();

      builder.RegisterType<ClaimsIdentityReader>().As<IIdentityReader>();

      builder.RegisterType<ClaimsIdentityFactory>().As<IClaimsIdentityFactory>();

      builder.RegisterType<CurrentThreadPrincipalGetter>().As<IPrincipalGetter>();

      builder.RegisterType<LoginLogoutManager>().As<ILoginLogoutManager>();

      builder
        .Register((context, parameters) => {
          IAuthenticationManager output;

          var ctx = HttpContext.Current.GetOwinContext();
          ctx.TraceOutput = Console.Out;
          output = ctx.Authentication;

          return output;
        })
        .As<IAuthenticationManager>();

      builder
        .Register(ctx => new PBKDF2PasswordVerifier(iterationCount: 20000))
        .As<ICredentialsCreator>();

      builder
        .RegisterType<JsonCredentialsSerializer>()
        .As<ICredentialsSerializer>();
    }
  }
}
