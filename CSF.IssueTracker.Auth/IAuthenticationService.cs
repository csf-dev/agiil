using System;

namespace CSF.IssueTracker.Auth
{
  public interface IAuthenticationService : CSF.Security.IAuthenticationService<LoginCredentials>
  {
  }
}
