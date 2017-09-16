using System;
using CSF.Screenplay.Abilities;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.Abilities
{
  public class LogInWithAUserAccount : Ability
  {
    string username, password;

    public string Username => username;
    public string Password => password;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} has a user account named '{username}' with the password '{password}'.";

    public LogInWithAUserAccount(string username, string password)
    {
      this.username = username;
      this.password = password;
    }

    public static LogInWithAUserAccountBuilder WithTheUsername(string username)
    {
      return new LogInWithAUserAccountBuilder(username);
    }

    public class LogInWithAUserAccountBuilder
    {
      readonly string username;

      public LogInWithAUserAccount AndThePassword(string password)
      {
        return new LogInWithAUserAccount(username, password);
      }

      internal LogInWithAUserAccountBuilder(string username)
      {
        this.username = username;
      }
    }
  }
}
