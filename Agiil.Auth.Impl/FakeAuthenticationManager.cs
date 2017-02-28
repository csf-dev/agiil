using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace Agiil.Auth
{
  public class FakeAuthenticationManager : IAuthenticationManager
  {
    public AuthenticationResponseChallenge AuthenticationResponseChallenge
    {
      get {
        throw new NotImplementedException();
      }

      set {
        throw new NotImplementedException();
      }
    }

    public AuthenticationResponseGrant AuthenticationResponseGrant
    {
      get {
        throw new NotImplementedException();
      }

      set {
        throw new NotImplementedException();
      }
    }

    public AuthenticationResponseRevoke AuthenticationResponseRevoke
    {
      get {
        throw new NotImplementedException();
      }

      set {
        throw new NotImplementedException();
      }
    }

    public ClaimsPrincipal User
    {
      get {
        throw new NotImplementedException();
      }

      set {
        throw new NotImplementedException();
      }
    }

    public Task<IEnumerable<AuthenticateResult>> AuthenticateAsync(string[] authenticationTypes)
    {
      throw new NotImplementedException();
    }

    public Task<AuthenticateResult> AuthenticateAsync(string authenticationType)
    {
      throw new NotImplementedException();
    }

    public void Challenge(params string[] authenticationTypes)
    {
      throw new NotImplementedException();
    }

    public void Challenge(AuthenticationProperties properties, params string[] authenticationTypes)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<AuthenticationDescription> GetAuthenticationTypes()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<AuthenticationDescription> GetAuthenticationTypes(Func<AuthenticationDescription, bool> predicate)
    {
      throw new NotImplementedException();
    }

    public void SignIn(params ClaimsIdentity[] identities)
    {
      throw new NotImplementedException();
    }

    public void SignIn(AuthenticationProperties properties, params ClaimsIdentity[] identities)
    {
      System.Threading.Thread.CurrentPrincipal = new ClaimsPrincipal(identities);
    }

    public void SignOut(params string[] authenticationTypes)
    {
      throw new NotImplementedException();
    }
  }
}
