﻿using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Auth
{
  public class ChangeTheirPassword : Performable
  {
    string oldPassword, newPassword;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} tries to change their password from '{oldPassword}' to {newPassword}";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<ChangePassword>());
      actor.Perform(Enter.TheText(oldPassword).Into(ChangePassword.ExistingPassword));
      actor.Perform(Enter.TheText(newPassword).Into(ChangePassword.NewPassword));
      actor.Perform(Enter.TheText(newPassword).Into(ChangePassword.ConfirmNewPassword));
      actor.Perform(Navigate.ToAnotherPageByClicking(ChangePassword.SubmitChangePasswordButton));
    }

    public static ChangeTheirPassword From(string old)
    {
      if(old == null)
        throw new ArgumentNullException(nameof(old));

      return new ChangeTheirPassword {
        oldPassword = old,
      };
    }

    public IPerformable To(string newPassword)
    {
      if(newPassword == null)
        throw new ArgumentNullException(nameof(newPassword));
      
      this.newPassword = newPassword;
      return this;
    }
  }
}
