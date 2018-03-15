using System;
namespace Agiil.Web.Services
{
  public class OverridableVersionInfoProvider : VersionInfoProvider
  {
    public string VersionOverride { get; set; }

    public override string GetHumanReadableProductVersion()
    {
      if(VersionOverride != null) return VersionOverride;
      return base.GetHumanReadableProductVersion();
    }
  }
}
