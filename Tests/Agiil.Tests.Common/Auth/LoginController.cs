﻿using System;
using Agiil.Auth;

namespace Agiil.Tests.Auth
{
  public class LoginController : ILoginController
  {
    readonly Web.Controllers.LoginController controller;

    public void Login(string username, string password)
    {
      controller.Login(new Web.Models.Auth.LoginCredentials { Username = username, Password = password });
    }

    public void Logout()
    {
      controller.Logout();
    }

    public LoginController (Web.Controllers.LoginController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      
      this.controller = controller;
    }
  }
}
