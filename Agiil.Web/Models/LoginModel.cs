using Agiil.Auth;

namespace Agiil.Web.Models
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
