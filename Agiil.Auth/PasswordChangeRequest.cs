using System;
using System.Text;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class PasswordChangeRequest
  {
    public string ExistingPassword { get; set; }

    public string NewPassword { get; set; }

    public string ConfirmNewPassword { get; set; }
  }
}
