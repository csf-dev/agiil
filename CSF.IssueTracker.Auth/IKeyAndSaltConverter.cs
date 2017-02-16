using System;
using CSF.Security;

namespace CSF.IssueTracker.Auth
{
  public interface IKeyAndSaltConverter
  {
    IStoredCredentialsWithKeyAndSalt GetKeyAndSalt(string authenticationInfo);

    IStoredCredentialsWithKeyAndSalt GetKeyAndSalt(IAuthenticationInfoProvider provider);
  }
}
