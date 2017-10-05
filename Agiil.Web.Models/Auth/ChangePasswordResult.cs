using System;
namespace Agiil.Web.Models.Auth
{
  public class ChangePasswordResult
  {
    public bool Success { get; set; }
    
    public bool Failure => !Success;

    public bool ExistingPasswordIncorrect { get; set; }

    public bool NewPasswordDoesNotMatchConfirmation { get; set; }

    public bool NewPasswordDoesNotSatisfyPolicy { get; set; }
  }
}
