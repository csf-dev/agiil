using System.Web;
using Autofac;
using Agiil.Auth;
using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace Agiil.Bootstrap.Auth
{
  public class AuthModule : Module
  {
    protected override void Load (ContainerBuilder builder)
    {
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
      var sourceAddress = parameters.Named<string>("sourceAddress");

      var credentials = new LoginCredentials { Username = username, Password = password };

      return new LoginRequest(credentials, sourceAddress);
    }

    IAuthenticationManager GetAuthenticationManagerFromCurrentOwinContext(IComponentContext ctx)
    {
      var owinContext = HttpContext.Current.GetOwinContext();
      return owinContext.Authentication;
    }
  }
}
