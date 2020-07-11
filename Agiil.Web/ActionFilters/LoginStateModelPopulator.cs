using System;
using System.Web.Mvc;
using Agiil.Web.Models.Shared;
using Agiil.Web.Services.Auth;
using CSF.ORM;
using log4net;

namespace Agiil.Web.ActionFilters
{
    public class LoginStateModelPopulator : IActionFilter
    {
        readonly LoginStateReader loginStateReader;
        private readonly ILog logger;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if(viewResult == null) return;

            try
            {
                viewResult.ViewBag.LoginState = loginStateReader.GetLoginState();
            }
            catch(Exception e)
            {
                logger.Warn("Caught exception whilst populating state; as this is non-critical it is being ignored.  The exception will be recorded at DEBUG level.");
                logger.Debug(e);
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

        public LoginStateModelPopulator(LoginStateReader loginStateReader, ILog logger)
        {
            this.loginStateReader = loginStateReader ?? throw new ArgumentNullException(nameof(loginStateReader));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
