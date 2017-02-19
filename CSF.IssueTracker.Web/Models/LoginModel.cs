using System;
using CSF.IssueTracker.Auth;

namespace CSF.IssueTracker.Web.Models
{
  public class LoginModel
  {
    readonly LoginResult result;

    public LoginResult Result => result;

    public LoginModel(LoginResult result)
    {
      this.result = result;
    }
  }
}
