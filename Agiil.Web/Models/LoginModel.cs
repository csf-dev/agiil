using Agiil.Auth;

namespace Agiil.Web.Models
{
  public class LoginModel
  {
    readonly LoginResult result;
    readonly ICurrentUserInfo userInfo;

    public bool LoginFailed => LoginAttempted && !result.Success;

    public bool LoginSucceded => LoginAttempted && result.Success;

    public bool LoginAttempted => result != null;

    public string Username => userInfo?.Username;

    public LoginResult Result => result;

    public LoginModel(LoginResult result, ICurrentUserInfo userInfo)
    {
      this.userInfo = userInfo;
      this.result = result;
    }
  }
}
