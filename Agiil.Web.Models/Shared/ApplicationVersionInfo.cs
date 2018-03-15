using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain;

namespace Agiil.Web.Models.Shared
{
  public class ApplicationVersionInfo
  {
    const string
      NoVersionInfo = @"<!-- No detailled version information available -->",
      VersionInfoComment = @"<!--
Version information
===================
{0}
-->";

    public string HumanReadableProductVersion { get; set; }

    public IReadOnlyCollection<ComponentVersionInfo> ComponentVersions { get; set; }

    public string ComponentVersionHtmlComment
    {
      get {
        var usefulVersions = GetUsefulComponentVersions();
        if(!usefulVersions.Any()) return NoVersionInfo;
        return String.Format(VersionInfoComment, FormatVersionInfo(usefulVersions));
      }
    }

    ICollection<ComponentVersionInfo> GetUsefulComponentVersions()
    {
      if(ComponentVersions == null) return new ComponentVersionInfo[0];

      return ComponentVersions
        .Where(x => x != null && !String.IsNullOrEmpty(x.ComponentName) && !String.IsNullOrEmpty(x.Version))
        .ToArray();
    }

    string FormatVersionInfo(ComponentVersionInfo version, int lengthOfLongestComponentName)
    {
      var paddedName = version.ComponentName.PadRight(lengthOfLongestComponentName);
      return String.Format("{0} : {1}", paddedName, version.Version);
    }

    string FormatVersionInfo(IEnumerable<ComponentVersionInfo> versions)
    {
      var maxComponentNameLength = versions.Select(x => x.ComponentName).Max(x => x.Length);
      return String.Join(Environment.NewLine, versions.Select(x => FormatVersionInfo(x, maxComponentNameLength)));
    }
  }
}
