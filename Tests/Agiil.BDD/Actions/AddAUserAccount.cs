using System;
using CSF.Screenplay.JsonApis.Abilities;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using Agiil.BDD.ServiceEndpoints;

namespace Agiil.BDD.Actions
{
  public class AddAUserAccount : Performable
  {
    string username, password;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} adds a user account with username '{username}' and password '{password}'.";

    protected override void PerformAs(IPerformer actor)
    {
      var ability = actor.GetAbility<ConsumeJsonWebServices>();
      var invocation = new AddUserAccountService(username, password);
      ability.Execute(invocation);
    }

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
