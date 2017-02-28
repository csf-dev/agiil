using System;
using CSF.Security;

namespace Agiil.Auth
{
  public interface IKeyAndSaltConverter
  {
    IStoredCredentialsWithKeyAndSalt GetKeyAndSalt(string authenticationInfo);

    IStoredCredentialsWithKeyAndSalt GetKeyAndSalt(IAuthenticationInfoProvider provider);
  }
}
