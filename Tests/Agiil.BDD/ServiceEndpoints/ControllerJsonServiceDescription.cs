using System;
using System.Text.RegularExpressions;
using CSF.Screenplay.WebApis;

namespace Agiil.BDD.ServiceEndpoints
{
  public abstract class ControllerJsonServiceDescription : RelativeEndpoint
  {
    const string ControllerSuffixPattern = "Controller$";
    static readonly Regex SuffixRemover = new Regex(ControllerSuffixPattern, RegexOptions.Compiled);

    protected override string GetRelativeUriString() => SuffixRemover.Replace(GetControllerName(), String.Empty);

    protected abstract string GetControllerName();
  }
}
