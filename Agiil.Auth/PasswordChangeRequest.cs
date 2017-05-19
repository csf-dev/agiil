using System;
using System.Text;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class PasswordChangeRequest : IPassword
  {
    public string ExistingPassword { get; set; }

    public string NewPassword { get; set; }

    public string ConfirmNewPassword { get; set; }

    string IPassword.Password => ExistingPassword;

    byte[] IPassword.GetPasswordAsByteArray()
    {
      if (ExistingPassword == null)
        return null;
      
      return Encoding.UTF8.GetBytes(ExistingPassword);
    }
  }
}
