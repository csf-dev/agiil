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
        throw new NotSupportedException();
      }

      set {
        throw new NotSupportedException();
      }
    }

    public AuthenticationResponseGrant AuthenticationResponseGrant
    {
      get {
        throw new NotSupportedException();
      }

      set {
        throw new NotSupportedException();
      }
    }

    public AuthenticationResponseRevoke AuthenticationResponseRevoke
    {
      get {
        throw new NotSupportedException();
      }

      set {
        throw new NotSupportedException();
      }
    }

    public ClaimsPrincipal User
    {
      get {
        throw new NotSupportedException();
      }

      set {
        throw new NotSupportedException();
      }
    }

    public Task<IEnumerable<AuthenticateResult>> AuthenticateAsync(string[] authenticationTypes)
    {
      throw new NotSupportedException();
    }

    public Task<AuthenticateResult> AuthenticateAsync(string authenticationType)
    {
      throw new NotSupportedException();
    }

    public void Challenge(params string[] authenticationTypes)
    {
      throw new NotSupportedException();
    }

    public void Challenge(AuthenticationProperties properties, params string[] authenticationTypes)
    {
      throw new NotSupportedException();
    }

    public IEnumerable<AuthenticationDescription> GetAuthenticationTypes()
    {
      throw new NotSupportedException();
    }

    public IEnumerable<AuthenticationDescription> GetAuthenticationTypes(Func<AuthenticationDescription, bool> predicate)
    {
      throw new NotSupportedException();
    }

    public void SignIn(params ClaimsIdentity[] identities)
    {
      SignIn(null, identities);
    }

    public void SignIn(AuthenticationProperties properties, params ClaimsIdentity[] identities)
    {
      System.Threading.Thread.CurrentPrincipal = new ClaimsPrincipal(identities);
    }

    public void SignOut(params string[] authenticationTypes)
    {
      throw new NotSupportedException();
    }

    public void SignOut(AuthenticationProperties properties, params string[] authenticationTypes)
    {
      throw new NotSupportedException();
    }
  }
}
