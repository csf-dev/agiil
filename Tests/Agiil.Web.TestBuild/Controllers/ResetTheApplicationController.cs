using System;
using System.Web.Http;
using Agiil.Web.TestBuild.Services;

namespace Agiil.Web.TestBuild.Controllers
{
  [AllowAnonymous]
  public class ResetTheApplicationController : ApiController
  {
    readonly DatabaseMaintainer maintainer;

    [AllowAnonymous]
    public IHttpActionResult Post()
    {
      maintainer.Reset();
      return Ok();
    }

    public ResetTheApplicationController(DatabaseMaintainer maintainer)
    {
      if(maintainer == null)
        throw new ArgumentNullException(nameof(maintainer));

      this.maintainer = maintainer;
    }
  }
}
