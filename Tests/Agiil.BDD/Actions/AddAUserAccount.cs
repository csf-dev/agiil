using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using Agiil.BDD.ServiceEndpoints;
using CSF.Screenplay.WebApis.Builders;
using Agiil.Web.Models;

namespace Agiil.BDD.Actions
{
  public class AddAUserAccount : Performable
  {
    string username, password;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} adds a user account with username '{username}' and password '{password}'.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Invoke.TheJsonWebService<AddUserAccountService>().WithTheData(GetUserDetails()).AndVerifyItSucceeds());
    }

    CreateUserModel GetUserDetails()
      => new CreateUserModel { username = username, password = password };

    public AddAUserAccount(string username, string password)
    {
      this.username = username;
      this.password = password;
    }

    public static AddUserAccountBuilder WithTheUsername(string username)
    {
      return new AddUserAccountBuilder(username);
    }

    public class AddUserAccountBuilder
    {
      readonly string username;

      public IPerformable AndThePassword(string password)
      {
        return new AddAUserAccount(username, password);
      }

      internal AddUserAccountBuilder(string username)
      {
        this.username = username;
      }
    }
  }
}
