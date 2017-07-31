using System;
using System.Web;
using Autofac;
using Agiil.Auth;
using CSF.Security.Authentication;
using Microsoft.Owin.Security;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Agiil.Bootstrap.Auth
{
  public class AuthModule : NamespaceModule
  {
    protected override IEnumerable<Type> TypesNotToRegisterAutomatically
    {
      get {
        return new [] { typeof(LoginRequest), };
      }
    }

    protected override string Namespace => typeof(AuthenticationService).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        Assembly.GetAssembly(typeof(Agiil.Auth.IAuthenticationResult)),
        Assembly.GetAssembly(typeof(Agiil.Auth.AuthenticationResult)),
      };
    }

    protected override void Load (ContainerBuilder builder)
    {
      AspNetWebApiModule.Load(base, builder);

      builder
        .Register((context, parameters) => {
          var username = parameters.Named<string>("username");
          var password = parameters.Named<string>("password");

          var credentials = new LoginCredentials { Username = username, Password = password };

          return new LoginRequest(credentials);
        })
        .As<ILoginRequest>();

      builder
        .Register((context, parameters) => {
          IAuthenticationManager output;

          var ctx = HttpContext.Current.GetOwinContext();
          ctx.TraceOutput = Console.Out;
          output = ctx.Authentication;

          return output;
        })
        .As<IAuthenticationManager>();
    }
  }
}
