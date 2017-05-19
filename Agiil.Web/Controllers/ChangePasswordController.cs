using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Web.Models;

namespace Agiil.Web.Controllers
{
  public class ChangePasswordController : ControllerBase
  {
    const string ResultKey = "Change password result";

    readonly Lazy<IPasswordChanger> passwordChanger;

    [HttpGet]
    public ActionResult Index()
    {
      var model = GetModel();

      if(model.Result != null
         && model.Result.Success)
      {
        return View("Success", model);
      }

      return View(model);
    }

    [HttpPost]
    public ActionResult Change(ChangePasswordSpecification spec)
    {
      if(spec == null)
        throw new ArgumentNullException(nameof(spec));

      var request = MapRequest(spec);
      var result = passwordChanger.Value.ChangeOwnPassword(request);
      var webResult = GetResult(result);

      TempData.Clear();

      TempData.Add(ResultKey, webResult);
      return RedirectToAction(nameof(Index));
    }

    ChangePasswordModel GetModel()
    {
      var model = ModelFactory.GetModel<ChangePasswordModel>();
      model.Result = GetTempData<ChangePasswordResult>(ResultKey);
      return model;
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

    public ChangePasswordController(Services.SharedModel.StandardPageModelFactory modelFactory,
                                    Lazy<IPasswordChanger> passwordChanger)
      : base(modelFactory)
    {
      if(passwordChanger == null)
        throw new ArgumentNullException(nameof(passwordChanger));
      this.passwordChanger = passwordChanger;
    }
  }
}
