using System;
using System.Net.Http;
using CSF.Screenplay.Abilities;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.AppAbilities
{
  public class ActAsTheApplication : IAbility
  {
    readonly TimeSpan requestTimeout;
    readonly HttpClient httpClient;

    public void PerformRequest(HttpRequestMessage request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));
      
      var success = httpClient.SendAsync(request).Wait(requestTimeout);
      if(!success)
        throw new TimeoutException($"Timeout acting as the application, gave up after {requestTimeout.ToString("g")}.");
    }

    public string GetReport(INamed actor) => $"{actor.Name} can act directly as the application.";

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

    #region IDisposable Support
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if(!disposed)
      {
        if(disposing)
        {
          httpClient.Dispose();
        }

        disposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
    }
    #endregion
  }
}
