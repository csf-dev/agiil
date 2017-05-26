using System;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Web.Models.Auth;
using AutoMapper;

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

    // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
    PasswordChangeRequest MapRequest(ChangePasswordSpecification spec)
    {
      return new PasswordChangeRequest {
        ConfirmNewPassword = spec.NewPasswordConfirmation,
        ExistingPassword = spec.ExistingPassword,
        NewPassword = spec.NewPassword,
      };
    }

    // TODO: #AG30 - Switch this over to use an IMapper (auto-mapper)
    ChangePasswordResult GetResult(PasswordChangeResponse result)
    {
      return new ChangePasswordResult {
        Success = result.Success,
        ExistingPasswordIncorrect = result.ExistingPasswordIncorrect,
        NewPasswordDoesNotMatchConfirmation = result.NewPasswordDoesNotMatchConfirmation,
        NewPasswordDoesNotSatisfyPolicy = result.NewPasswordDoesNotSatisfyPolicy,
      };
    }

    public ChangePasswordController(ControllerBaseDependencies baseDeps,
                                    Lazy<IPasswordChanger> passwordChanger)
      : base(baseDeps)
    {
      if(passwordChanger == null)
        throw new ArgumentNullException(nameof(passwordChanger)); ;
      this.passwordChanger = passwordChanger;
    }
  }
}
