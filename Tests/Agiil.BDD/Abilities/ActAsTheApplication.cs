using System;
using System.Net.Http;
using CSF.Screenplay.Abilities;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.Abilities
{
  public class ActAsTheApplication : Ability
  {
    readonly TimeSpan requestTimeout;
    readonly HttpClient httpClient;

    public void PerformRequest(HttpRequestMessage request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));


      var httpRequest = httpClient.SendAsync(request);
      var waitSuccess = httpRequest.Wait(requestTimeout);

      if(!waitSuccess)
        throw new TimeoutException($"Timeout acting as the application, gave up after {requestTimeout.ToString("g")}.");

      EnsureResultIsSuccess(httpRequest.Result);
    }

    protected override string GetReport(INamed actor)
      => $"{actor.Name} can act directly as the application.";

    protected override void Dispose(bool disposing)
    {
      if(disposing)
        httpClient.Dispose();
    }

    void EnsureResultIsSuccess(HttpResponseMessage message)
    {
      try
      {
        message.EnsureSuccessStatusCode();
      }
      catch(HttpRequestException ex)
      {
        var content = message.Content.ReadAsStringAsync();
        content.Wait(requestTimeout);
        var response = content.Result;

        throw new ApplicationApiException($@"The API request failed
{response}", ex);
      }
    }

    public ActAsTheApplication(Uri baseUri = null, TimeSpan? defaultTimeout = null)
    {
      httpClient = new HttpClient();
      if(baseUri != null)
        httpClient.BaseAddress = baseUri;
      else
        httpClient.BaseAddress = new Uri("http://localhost:8080/api/v1/");

      if(defaultTimeout.HasValue)
        requestTimeout = defaultTimeout.Value;
      else
        requestTimeout = TimeSpan.FromSeconds(10);
    }

    public ActAsTheApplication() : this(baseUri: null, defaultTimeout: null) {}
  }
}
