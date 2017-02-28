using System;
using CSF.Security;

namespace Agiil.Auth
{
  public interface IAuthenticationService : IAuthenticationService<LoginCredentials>
  {
  }
}
