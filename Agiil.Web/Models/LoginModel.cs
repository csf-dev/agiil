using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class LoginModel : StandardPageModel
  {
    public LoginResult Result { get; set; }

    public virtual LoginCredentials EnteredCredentials { get; set; }

    public string ReturnUrl { get; set; }

    public bool LoginFailed => LoginAttempted && !Result.Success;

    public bool LoginSucceded => LoginAttempted && Result.Success;

    public bool LoginAttempted => Result != null;
  }
}
