using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Auth
{
  public class ChangeTheirPassword : Performable
  {
    string oldPassword, newPassword;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} tries to change their password from '{oldPassword}' to {newPassword}";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<ChangePasswordPage>());
      actor.Perform(Enter.TheText(oldPassword).Into(ChangePasswordPage.ExistingPassword));
      actor.Perform(Enter.TheText(newPassword).Into(ChangePasswordPage.NewPassword));
      actor.Perform(Enter.TheText(newPassword).Into(ChangePasswordPage.ConfirmNewPassword));
      actor.Perform(Click.On(ChangePasswordPage.SubmitChangePasswordButton));
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
