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
    {
      if(oldPassword != null)
        return $"{actor.Name} tries to change their password from '{oldPassword}' to {newPassword}";

      return $"{actor.Name} tries to change their password from their old password to {newPassword}";
    }

    protected override void PerformAs(IPerformer actor)
    {
      var old = oldPassword;

      if(old == null && actor.HasAbility<LogInWithAUserAccount>())
      {
        var loginAbility = actor.GetAbility<LogInWithAUserAccount>();
        old = loginAbility.Password;
      }

      actor.Perform(Enter.TheText(old).Into(ChangePasswordPage.ExistingPassword));
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

    public static IPerformable FromTheirOldPasswordTo(string newPassword)
    {
      if(newPassword == null)
        throw new ArgumentNullException(nameof(newPassword));

      return new ChangeTheirPassword {
        oldPassword = null,
        newPassword = newPassword,
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
