using System;
using System.Net.Http;
using Agiil.Web.Controllers;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Actions
{
  public class AddAUserAccount : ApplicationApiAction
  {
    string username, password;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} adds a user account with username '{username}' and password '{password}'.";

    protected override string GetControllerName() => nameof(AddUserController);

    protected override object GetHttpRequestContentData() => new { username, password };

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
