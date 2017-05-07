using System;
using Microsoft.Owin.Security.Jwt;

namespace Agiil.Web.OAuth
{
  public interface IJwtBearerAuthenticationOptionsFactory
  {
    JwtBearerAuthenticationOptions GetOptions();
  }
}
