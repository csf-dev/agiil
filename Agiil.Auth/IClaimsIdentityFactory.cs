using System;
using System.Security.Claims;
using CSF.Entities;

namespace Agiil.Auth
{
  public interface IClaimsIdentityFactory
  {
    ClaimsIdentity GetIdentity(IAuthenticationResult result, string authenticationType);

    ClaimsIdentity GetIdentity(string username, IIdentity userIdentity, string authenticationType);
  }
}
