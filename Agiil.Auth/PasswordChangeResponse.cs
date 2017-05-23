using System;
namespace Agiil.Auth
{
  public class PasswordChangeResponse
  {
    public bool ExistingPasswordIncorrect { get; set; }

    public bool NewPasswordDoesNotMatchConfirmation { get; set; }

    public bool NewPasswordDoesNotSatisfyPolicy { get; set; }

    public bool Success
      => !(ExistingPasswordIncorrect || NewPasswordDoesNotMatchConfirmation || NewPasswordDoesNotSatisfyPolicy);
  }
}
