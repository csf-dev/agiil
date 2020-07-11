using System;
using System.Web.Mvc;
using Agiil.Web.Models.Shared;
using Agiil.Web.Services.Auth;
using CSF.ORM;

namespace Agiil.Web.ActionFilters
{
    public class LoginStateModelPopulator : IActionFilter
    {
        readonly LoginStateReader loginStateReader;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if(viewResult == null) return;

            var loginStateModel = viewResult.Model as IHasLoginState;
            if(loginStateModel == null) return;

            Populate(loginStateModel);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

        void Populate(IHasLoginState model)
        {
            model.LoginState = loginStateReader.GetLoginState();
        }

        public LoginStateModelPopulator(LoginStateReader loginStateReader)
        {
            this.loginStateReader = loginStateReader ?? throw new ArgumentNullException(nameof(loginStateReader));
        }
    }
}
