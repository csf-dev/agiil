using System;
namespace CSF.IssueTracker.Auth
{
  public interface ILoginRequest
  {
    LoginCredentials GetCredentials();
  }
}
