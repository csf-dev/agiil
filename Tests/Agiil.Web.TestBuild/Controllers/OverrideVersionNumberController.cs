using System;
using System.Web.Http;
using Agiil.Web.Services;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class OverrideVersionNumberController : ApiController
  {
    readonly OverridableVersionInfoProvider provider;

    public IHttpActionResult Post(OverrideVersionRequest request)
    {
      if(request == null || request.IsEmptyVersion) provider.VersionOverride = null;
      else provider.VersionOverride = request.Version;

      return Ok();
    }

    public OverrideVersionNumberController(OverridableVersionInfoProvider provider)
    {
      if(provider == null)
        throw new ArgumentNullException(nameof(provider));
      this.provider = provider;
    }

    public class OverrideVersionRequest
    {
      public string version { get; set; }

      public string Version => version;

      public bool IsEmptyVersion => String.IsNullOrEmpty(version);
    }
  }
}
