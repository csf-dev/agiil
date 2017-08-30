using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Agiil.BDD.Abilities;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using Newtonsoft.Json;

namespace Agiil.BDD.Actions
{
  public abstract class ApplicationApiAction : Performable
  {
    const string
      ControllerSuffixPattern = "Controller$",
      JsonMimeType = "application/json";
    static readonly Regex SuffixRemover = new Regex(ControllerSuffixPattern, RegexOptions.Compiled);

    protected override void PerformAs(IPerformer actor)
    {
      var ability = GetAbility(actor);
      var request = GetHttpRequest();
      ability.PerformRequest(request);
    }

    protected abstract string GetControllerName();

    protected virtual HttpRequestMessage GetHttpRequest()
    {
      var output = GetPostRequest(GetControllerName());

      var content = GetHttpContent();
      if(content != null)
        output.Content = content;

      return output;
    }

    protected virtual ActAsTheApplication GetAbility(IPerformer actor)
    {
      return actor.GetAbility<ActAsTheApplication>();
    }

    protected virtual Uri GetApplicationApiUri(string controllerName)
    {
      if(controllerName == null)
        throw new ArgumentNullException(nameof(controllerName));
      
      return new Uri(SuffixRemover.Replace(controllerName, String.Empty), UriKind.Relative);
    }

    protected virtual HttpRequestMessage GetPostRequest(string controllerName)
    {
      return new HttpRequestMessage {
        Method = HttpMethod.Post,
        RequestUri = GetApplicationApiUri(controllerName),
      };
    }

    protected virtual HttpContent GetHttpContent()
    {
      var content = GetHttpRequestContentData();
      if(ReferenceEquals(content, null))
        return null;

      var serializedContent = SerializeContentToJson(content);
      return new StringContent(serializedContent, Encoding.UTF8, JsonMimeType);
    }

    protected virtual string SerializeContentToJson(object content)
    {
      var serializer = new JsonSerializer();
      var sb = new StringBuilder();

      using(var writer = new StringWriter(sb))
      {
        serializer.Serialize(writer, content);
        writer.Flush();
      }

      return sb.ToString();
    }

    protected virtual object GetHttpRequestContentData() => null;
  }
}
