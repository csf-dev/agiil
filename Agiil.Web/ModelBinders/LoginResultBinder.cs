using System;
using System.Linq;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Web.Models;
using Autofac.Integration.Mvc;

namespace Agiil.Web.ModelBinders
{
  [ModelBinderType(typeof(LoginResult))]
  public class LoginResultBinder : IModelBinder
  {
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      if(controllerContext.Controller.GetType() != typeof(Controllers.LoginController))
      {
        return null;
      }

      var successString = controllerContext.HttpContext.Request[nameof(LoginResult.Success)];
      var username = controllerContext.HttpContext.Request[nameof(LoginResult.Username)];

      bool success;
      if(Boolean.TryParse(successString, out success))
      {
        if(success)
        {
          var user = new UsernameUserInfo {
            Username = username
          };
          return new LoginResult(user);
        }
        else
        {
          return LoginResult.LoginFailed;
        }
      }

      return null;
    }
  }
}
