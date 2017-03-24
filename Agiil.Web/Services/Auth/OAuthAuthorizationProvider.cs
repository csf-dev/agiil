using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Agiil.Auth;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.Services.Auth
{
  public class OAuthAuthorizationProvider : OAuthAuthorizationServerProvider
  {
    protected IDependencyResolver GetDependencyResolver()
    {
      return GlobalConfiguration.Configuration.DependencyResolver;
    }

    protected virtual CSF.Security.Authentication.IPasswordAuthenticationService GetAuthenticationService(IDependencyScope scope)
    {
      var output = scope.GetService(typeof(CSF.Security.Authentication.IPasswordAuthenticationService));
      return (CSF.Security.Authentication.IPasswordAuthenticationService) output;
    }

    protected virtual LoginRequestCreator GetLoginRequestCreator(IDependencyScope scope)
    {
      return (LoginRequestCreator) scope.GetService(typeof(LoginRequestCreator));
    }

    protected virtual IClaimsIdentityFactory GetClaimsIdentityFactory(IDependencyScope scope)
    {
      return (IClaimsIdentityFactory) scope.GetService(typeof(IClaimsIdentityFactory));
    }

    public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      var resolver = GetDependencyResolver();
      using(var scope = resolver.BeginScope())
      {
        var requestCreator = GetLoginRequestCreator(scope);
        var request = requestCreator(context.UserName, context.Password);

        var authService = GetAuthenticationService(scope);
        var result = (IAuthenticationResult) authService.Authenticate(request.GetCredentials());

        if(!result.Success)
        {
          context.SetError("invalid_grant", "The user name or password is incorrect");
          context.Rejected();
          return Task.FromResult<object>(null);
        }

        var identityFactory = GetClaimsIdentityFactory(scope);
        var identity = identityFactory.GetIdentity(result, "JWT");
        context.Validated(identity);

        return Task.FromResult<object>(null);
      }
    }

    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
      return Task.FromResult<object>(null);
    }
  }
}
