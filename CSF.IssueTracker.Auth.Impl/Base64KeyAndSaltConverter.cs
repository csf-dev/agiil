using System;
using CSF.Security;

namespace CSF.IssueTracker.Auth
{
  public class Base64KeyAndSaltConverter : IKeyAndSaltConverter
  {
    #region constants

    const char SPACER = ':';

    #endregion

    #region methods

    public IStoredCredentialsWithKeyAndSalt GetKeyAndSalt (string authenticationInfo)
    {
      if (authenticationInfo == null) {
        throw new ArgumentNullException (nameof (authenticationInfo));
      }

      var parts = authenticationInfo.Split(SPACER);
      if(parts.Length != 2)
      {
        throw new ArgumentException("Authentication info must comprise of two parts separated by a colon",
                                    nameof(authenticationInfo));
      }

      return new Base64KeyAndSalt() {
        Salt = parts[0],
        Key = parts[1],
      };
    }

    #endregion
  }
}
