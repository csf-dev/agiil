using Agiil.Auth;
using Agiil.Domain.Auth;

namespace Agiil.Web.Models
{
  public class LoginModel
  {
    readonly LoginResult result;
    readonly ICurrentUserInfo userInfo;
    readonly LoginCredentials enteredCredentials;

    public bool LoginFailed => LoginAttempted && !result.Success;

    public bool LoginSucceded => LoginAttempted && result.Success;

    public bool LoginAttempted => result != null;

    public string Username => userInfo?.Username;

    public LoginResult Result => result;

    public virtual LoginCredentials EnteredCredentials => enteredCredentials;

    public LoginModel(LoginResult result,
                      ICurrentUserInfo userInfo,
                      LoginCredentials enteredCredentials)
    {
      this.userInfo = userInfo;
      this.result = result;
      this.enteredCredentials = enteredCredentials;
    }
  }
}
