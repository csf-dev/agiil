using System;
using CSF.Security;

namespace Agiil.Auth
{
  public interface ICredentialsRepository : ICredentialsRepository<LoginCredentials,IStoredCredentialsWithKeyAndSalt>
  {
  }
}
