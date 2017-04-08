using System;
using System.Configuration;
using CSF.Configuration;

namespace Agiil.Web.Services.Config
{
  [ConfigurationPath("Agiil/OAuth")]
  public class OAuthConfigurationSection : ConfigurationSection, IOAuthConfiguration
  {
    #region configuration properties

    const string AccessTokenLifetimeMinutesConfigName = @"AccessTokenLifetimeMinutes";
    [ConfigurationProperty(AccessTokenLifetimeMinutesConfigName, IsRequired = false, DefaultValue = "30")]
    public virtual int AccessTokenLifetimeMinutes
    {
      get { return (int) this[AccessTokenLifetimeMinutesConfigName]; }
      set { this[AccessTokenLifetimeMinutesConfigName] = value; }
    }

    const string JwtIssuerNameConfigName = @"JwtIssuerName";
    [ConfigurationProperty(JwtIssuerNameConfigName, IsRequired = false, DefaultValue = "Agiil")]
    public virtual string JwtIssuerName
    {
      get { return (string) this[JwtIssuerNameConfigName]; }
      set { this[JwtIssuerNameConfigName] = value; }
    }

    const string Base64JwtSecretKeyConfigName = @"Base64JwtSecretKey";
    [ConfigurationProperty(Base64JwtSecretKeyConfigName, IsRequired = true)]
    public virtual string Base64JwtSecretKey
    {
      get { return (string) this[Base64JwtSecretKeyConfigName]; }
      set { this[Base64JwtSecretKeyConfigName] = value; }
    }

    #endregion

    #region methods

    public TimeSpan GetAccessTokenExpiryLifetime()
    {
      if(AccessTokenLifetimeMinutes < 0)
      {
        throw new InvalidOperationException("The access token lifetime expiry minutes must not be less than zero.");
      }

      return TimeSpan.FromMinutes(AccessTokenLifetimeMinutes);
    }

    #endregion
  }
}
