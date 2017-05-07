using System;
namespace Agiil.Web.OAuth
{
  public interface IOAuthConfiguration
  {
    TimeSpan GetAccessTokenExpiryLifetime();

    string JwtIssuerName { get; }

    string Base64JwtSecretKey { get; }
  }
}
