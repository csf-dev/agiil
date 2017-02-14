using System;
namespace Agiil.Web.Services.Config
{
  public interface IOAuthConfiguration
  {
    TimeSpan GetAccessTokenExpiryLifetime();

    string JwtIssuerName { get; }

    string Base64JwtSecretKey { get; }
  }
}
