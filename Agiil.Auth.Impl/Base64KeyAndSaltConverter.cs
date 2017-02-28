using System;
using System.Diagnostics.Contracts;
using CSF.Security;

namespace Agiil.Auth
{
  public class Base64KeyAndSaltConverter : IKeyAndSaltConverter
  {
    const char SPACER = ':';

    public IStoredCredentialsWithKeyAndSalt GetKeyAndSalt (IAuthenticationInfoProvider provider)
    {
      if (provider == null) {
        throw new ArgumentNullException (nameof (provider));
      }

      return GetKeyAndSalt(provider.GetAuthenticationInfo());
    }

    public IStoredCredentialsWithKeyAndSalt GetKeyAndSalt (string authenticationInfo)
    {
      if (authenticationInfo == null) {
        throw new ArgumentNullException (nameof (authenticationInfo));
      }

      var parts = authenticationInfo.Split(SPACER);
      if(parts.Length != 2)
      {
        throw new FormatException(Resources.ExceptionMessages.AuthenticationInfoMustBeFormattedCorrectly);
      }

      return new Base64KeyAndSalt {
        Salt = parts[0],
        Key = parts[1],
      };
    }
  }
}
