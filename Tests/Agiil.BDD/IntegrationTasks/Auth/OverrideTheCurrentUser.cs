using System;
using Agiil.BDD.Abilities;
using Agiil.Web.Services;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.IntegrationTasks.Auth
{
  public class OverrideTheCurrentUser : Performable
  {
    readonly IOverridesCurrentLogin overrider;
    readonly string username;

		protected override string GetReport(INamed actor)
      => $"{actor.Name} set the currently-logged-in user to {username}";

		protected override void PerformAs(IPerformer actor)
		{
      overrider.OverrideLogin(username);
		}

    OverrideTheCurrentUser(IOverridesCurrentLogin overrider, string username)
    {
      if(overrider == null)
        throw new ArgumentNullException(nameof(overrider));
      if(username == null)
        throw new ArgumentNullException(nameof(username));
      this.overrider = overrider;
      this.username = username;
    }

    public static OverrideTheCurrentUserBuilder Using(IOverridesCurrentLogin overrider)
    {
      return new OverrideTheCurrentUserBuilder(overrider);
    }

    public class OverrideTheCurrentUserBuilder
    {
      IOverridesCurrentLogin overrider;

      public IPerformable To(string username) => new OverrideTheCurrentUser(overrider, username);

      public OverrideTheCurrentUserBuilder(IOverridesCurrentLogin overrider)
      {
        if(overrider == null)
          throw new ArgumentNullException(nameof(overrider));
        this.overrider = overrider;
      }
    }
  }
}
