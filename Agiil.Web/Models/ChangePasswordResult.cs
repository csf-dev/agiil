﻿using System;
namespace Agiil.Web.Models
{
  public class ChangePasswordResult
  {
    public bool Success { get; set; }

    public bool ExistingPasswordIncorrect { get; set; }

    public bool NewPasswordDoesNotMatchConfirmation { get; set; }

    public bool NewPasswordDoesNotSatisfyPolicy { get; set; }
  }
}
