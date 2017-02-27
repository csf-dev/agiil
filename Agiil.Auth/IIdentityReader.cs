using System;
using System.Security.Principal;

namespace CSF.IssueTracker.Auth
{
  public interface IIdentityReader
  {
    ICurrentUserInfo GetCurrentUserInfo();
  }
}
