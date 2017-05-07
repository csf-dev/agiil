using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.OAuth
{
  public class OAuthAuthorizationProvider : OAuthAuthorizationServerProvider
  {
    const string
      CorsAccessControlHeader = "Access-Control-Allow-Origin",
      CorsAllowAll = "*";

    readonly Func<IOAuthApplicationConnection> connectionFactory;

    public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      context.OwinContext.Response.Headers.Add(CorsAccessControlHeader, new[] { CorsAllowAll });

      using(var connection = connectionFactory())
      {
        var authChecker = connection.GetAuthChecker();

        authChecker.CheckAuthentication(context);
        return base.GrantResourceOwnerCredentials(context);
      }
    }

    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
      return base.ValidateClientAuthentication(context);
    }

    public OAuthAuthorizationProvider(Func<IOAuthApplicationConnection> connectionFactory)
    {
      if(connectionFactory == null)
      {
        throw new ArgumentNullException(nameof(connectionFactory));
      }

      this.connectionFactory = connectionFactory;
    }
  }
}
