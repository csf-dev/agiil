using System;
namespace CSF.IssueTracker.Auth
{
  public delegate ILoginRequest LoginRequestCreator(string username, string password);
}