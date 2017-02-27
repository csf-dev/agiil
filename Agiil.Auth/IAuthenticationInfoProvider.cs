using System;
namespace CSF.IssueTracker.Auth
{
  public interface IAuthenticationInfoProvider
  {
    string GetAuthenticationInfo();
  }
}
