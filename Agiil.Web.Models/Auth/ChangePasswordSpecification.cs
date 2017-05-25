using System;
namespace Agiil.Web.Models.Auth
{
  public class ChangePasswordSpecification
  {
    public string ExistingPassword { get; set; }

    public string NewPassword { get; set; }

    public string NewPasswordConfirmation { get; set; }
  }
}
