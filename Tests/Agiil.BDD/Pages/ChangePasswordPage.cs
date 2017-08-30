using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.Pages
{
  public class ChangePasswordPage : Page
  {
    public override string GetName() => "the change password page";

    public override IUriProvider GetUriProvider() => new AppUri("ChangePassword");

    public static ILocatorBasedTarget ExistingPassword
      => new CssSelector("#ExistingPassword", "the current password");

    public static ILocatorBasedTarget NewPassword
      => new CssSelector("#NewPassword", "the new password");

    public static ILocatorBasedTarget ConfirmNewPassword
      => new CssSelector("#NewPasswordConfirmation", "the new password confirmation");

    public static ILocatorBasedTarget SubmitChangePasswordButton
      => new CssSelector("#ChangePasswordButton", "the change button");

    public static ILocatorBasedTarget PasswordChangeFeedbackMessage
      => new CssSelector("#password_change_feedback", "the change-password feedback message");
  }
}
