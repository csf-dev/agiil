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
      base.Load(builder);

      builder
        .Register(GetLoginRequest)
        .As<ILoginRequest>();

      builder
        .Register(GetAuthenticationManagerFromCurrentOwinContext);
    }

    LoginRequest GetLoginRequest(IComponentContext ctx, IEnumerable<Autofac.Core.Parameter> parameters)
    {
      var username = parameters.Named<string>("username");
      var password = parameters.Named<string>("password");

      var credentials = new LoginCredentials { Username = username, Password = password };

      return new LoginRequest(credentials);
    }

    IAuthenticationManager GetAuthenticationManagerFromCurrentOwinContext(IComponentContext ctx)
    {
      var owinContext = HttpContext.Current.GetOwinContext();
      return owinContext.Authentication;
    }
  }
}
