using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Agiil.Auth;
using Autofac;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.Services.Auth
{
  public class OAuthAuthorizationProvider : OAuthAuthorizationServerProvider
  {
    #region fields

    readonly ILifetimeScope dependencyResolver;

    #endregion

    protected ILifetimeScope GetDependencyResolver()
    {
      return dependencyResolver;
    }

    protected virtual CSF.Security.Authentication.IPasswordAuthenticationService GetAuthenticationService(ILifetimeScope scope)
    {
      return scope.Resolve<CSF.Security.Authentication.IPasswordAuthenticationService>();
    }

    protected virtual LoginRequestCreator GetLoginRequestCreator(ILifetimeScope scope)
    {
      return scope.Resolve<LoginRequestCreator>();
    }

    protected virtual IClaimsIdentityFactory GetClaimsIdentityFactory(ILifetimeScope scope)
    {
      return scope.Resolve<IClaimsIdentityFactory>();
    }

    public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

      var resolver = GetDependencyResolver();
      using(var scope = resolver.BeginLifetimeScope())
      {
        var requestCreator = GetLoginRequestCreator(scope);
        var request = requestCreator(context.UserName, context.Password);

        var authService = GetAuthenticationService(scope);
        var result = (IAuthenticationResult) authService.Authenticate(request.GetCredentials());

        if(!result.Success)
        {
          context.SetError("invalid_grant", "The user name or password is incorrect");
          context.Rejected();
          return base.GrantResourceOwnerCredentials(context);
        }

        var identityFactory = GetClaimsIdentityFactory(scope);
        var identity = identityFactory.GetIdentity(result, "JWT");
        context.Validated(identity);

        return base.GrantResourceOwnerCredentials(context);
      }
    }

    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();

      return base.ValidateClientAuthentication(context);
    }

    #region constructor

    public OAuthAuthorizationProvider(ILifetimeScope resolver)
    {
      if(resolver == null)
      {
        throw new ArgumentNullException(nameof(resolver));
      }

      this.dependencyResolver = resolver;
    }

    #endregion
  }
}
