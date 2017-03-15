﻿using System;
using Agiil.Auth;
using Agiil.BDD.Controllers.Auth;

namespace Agiil.BDD.Auth
{
  public class LoginController : ILoginController
  {
    readonly Web.Controllers.LoginController controller;

    public void Login(string username, string password)
    {
      controller.Login(new Web.Models.LoginCredentials { Username = username, Password = password });
    }

    public LoginController (Web.Controllers.LoginController controller)
    {
      if(controller == null)
        throw new ArgumentNullException(nameof(controller));
      
      this.controller = controller;
    }
  }
}