using System;
using System.Text.RegularExpressions;
using CSF.Screenplay.JsonApis;

namespace Agiil.BDD.ServiceEndpoints
{
  public abstract class ControllerJsonServiceDescription : JsonServiceDescription
  {
    const string ControllerSuffixPattern = "Controller$";
    static readonly Regex SuffixRemover = new Regex(ControllerSuffixPattern, RegexOptions.Compiled);

    protected override string GetRelativeUriString() => SuffixRemover.Replace(GetControllerName(), String.Empty);

    protected abstract string GetControllerName();

    protected ControllerJsonServiceDescription(TimeSpan? timeout = null, object requestPayload = null)
      : base(timeout, requestPayload) {}
  }
}
