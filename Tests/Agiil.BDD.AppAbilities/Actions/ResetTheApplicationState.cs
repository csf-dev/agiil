using System;
using System.Net.Http;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.AppAbilities.Actions
{
  public class ResetTheApplicationState : ApplicationApiAction
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} resets the application to its known state.";

    protected override HttpRequestMessage GetHttpRequest()
    {
      return new HttpRequestMessage {
        Method = HttpMethod.Post,
        RequestUri = new Uri("ResetTheApplication", UriKind.Relative),
      };
    }

    public static IPerformable Now()
    {
      return new ResetTheApplicationState();
    }
  }
}
