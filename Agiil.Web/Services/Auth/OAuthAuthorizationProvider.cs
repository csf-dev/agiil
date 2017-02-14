using System;
using System.Threading.Tasks;
using Agiil.Auth;
using Autofac;
using Autofac.Features.OwnedInstances;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.Services.Auth
{
  public class OAuthAuthorizationProvider : OAuthAuthorizationServerProvider
  {
    const string
      CorsAccessControlHeader = "Access-Control-Allow-Origin",
      CorsAllowAll = "*";

    readonly Func<Owned<OAuthAuthorizationChecker>> authCheckerCreator;

    public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      context.OwinContext.Response.Headers.Add(CorsAccessControlHeader, new[] { CorsAllowAll });

      using(var authChecker = authCheckerCreator())
      {
        authChecker.Value.CheckAuthentication(context);
        return base.GrantResourceOwnerCredentials(context);
      }
    }

    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
      return base.ValidateClientAuthentication(context);
    }

    public OAuthAuthorizationProvider(Func<Owned<OAuthAuthorizationChecker>> authCheckerCreator)
    {
      if(authCheckerCreator == null)
      {
        throw new ArgumentNullException(nameof(authCheckerCreator));
      }

      this.authCheckerCreator = authCheckerCreator;
    }
  }
}
