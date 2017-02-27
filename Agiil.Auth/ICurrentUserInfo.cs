using System;
namespace CSF.IssueTracker.Auth
{
  public interface ICurrentUserInfo
  {
    string Username { get; }
  }
}
