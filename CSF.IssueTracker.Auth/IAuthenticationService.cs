using System;
using CSF.Security;

namespace CSF.IssueTracker.Auth
{
  public interface IAuthenticationService : IAuthenticationService<LoginCredentials>
  {
  }
}
