using System;
using System.Web.Http;
using Agiil.Auth;
using Agiil.Web.Models.Auth;

namespace Agiil.Web.ApiControllers
{
  public class ChangePasswordController : ApiController
  {
    readonly Lazy<IPasswordChanger> passwordChanger;

    public ChangePasswordResult Post(ChangePasswordSpecification spec)
    {
      if(spec == null)
        throw new ArgumentNullException(nameof(spec));

      var request = MapRequest(spec);
      var result = passwordChanger.Value.ChangeOwnPassword(request);
      return GetResult(result);
    }

    PasswordChangeRequest MapRequest(ChangePasswordSpecification spec)
    {
      return new PasswordChangeRequest
      {
        ConfirmNewPassword = spec.NewPasswordConfirmation,
        ExistingPassword = spec.ExistingPassword,
        NewPassword = spec.NewPassword,
      };
    }

    ChangePasswordResult GetResult(PasswordChangeResponse result)
    {
      return new ChangePasswordResult
      {
        Success = result.Success,
        ExistingPasswordIncorrect = result.ExistingPasswordIncorrect,
        NewPasswordDoesNotMatchConfirmation = result.NewPasswordDoesNotMatchConfirmation,
        NewPasswordDoesNotSatisfyPolicy = result.NewPasswordDoesNotSatisfyPolicy,
      };
    }

    public ChangePasswordController(Lazy<IPasswordChanger> passwordChanger)
    {
      if(passwordChanger == null)
        throw new ArgumentNullException(nameof(passwordChanger));
      this.passwordChanger = passwordChanger;
    }
  }
}
