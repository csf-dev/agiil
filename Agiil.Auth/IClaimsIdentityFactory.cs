using System;
using System.Security.Claims;

namespace Agiil.Auth
{
  public interface IClaimsIdentityFactory
  {
    ClaimsIdentity GetIdentity(IAuthenticationResult result, string authenticationType);
  }
}
