﻿using System;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Domain;
using Agiil.Domain.Auth;
using Agiil.Web.Models.Auth;
using Agiil.Web.Services.Auth;

namespace Agiil.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        #region constants

        public static readonly string
          LoginResultKey = "LoginResult",
          CredentialsKey = "Credentials";

        #endregion

        #region fields

        readonly LoginRequestCreator loginRequestCreator;
        readonly ILoginLogoutManager loginLogoutManager;
        readonly IValidatesRedirectUrls redirectUriValidator;

        #endregion

        #region controller actions

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            var model = GetLoginModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpGet]
        public ActionResult LoggedOut()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Auth.LoginCredentials credentials)
        {
            var loginRequest = loginRequestCreator(credentials.Username, credentials.Password, Request?.UserHostAddress);
            var result = loginLogoutManager.AttemptLogin(loginRequest);

            TempData.Clear();

            TempData.Add(LoginResultKey, result);
            TempData.Add(CredentialsKey, credentials);

            if(result.Success && redirectUriValidator.IsValid(credentials.ReturnUrl))
                return Redirect(credentials.ReturnUrl);

            return RedirectToAction(nameof(LoginController.Index), this.GetName<LoginController>());
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var result = loginLogoutManager.AttemptLogout();

            if(!result.Success)
            {
                // TODO: #AG32 - Determine what failing to log out means and then deal with it accordingly.
                throw new NotSupportedException("Failure to log out is not supported.");
            }

            Session?.Abandon();
            return RedirectToAction(nameof(LoginController.LoggedOut), this.GetName<LoginController>());
        }

        LoginModel GetLoginModel()
        {
            var model = new LoginModel();
            model.Result = TempData.TryGet<LoginResult>(LoginResultKey);
            model.EnteredCredentials = TempData.TryGet<Models.Auth.LoginCredentials>(CredentialsKey);
            return model;
        }

        #endregion

        #region constructor

        public LoginController(LoginRequestCreator loginRequestCreator,
                               ILoginLogoutManager loginLogoutManager,
                               IValidatesRedirectUrls redirectUriValidator)
        {
            if(redirectUriValidator == null)
                throw new ArgumentNullException(nameof(redirectUriValidator));
            if(loginLogoutManager == null)
                throw new ArgumentNullException(nameof(loginLogoutManager));
            if(loginRequestCreator == null)
                throw new ArgumentNullException(nameof(loginRequestCreator));

            this.redirectUriValidator = redirectUriValidator;
            this.loginRequestCreator = loginRequestCreator;
            this.loginLogoutManager = loginLogoutManager;
        }

        #endregion
    }
}
