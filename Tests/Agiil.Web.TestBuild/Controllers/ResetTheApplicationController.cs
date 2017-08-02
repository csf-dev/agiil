using System;
using System.Web.Http;
using Agiil.Web.TestBuild.Services;

namespace Agiil.Web.TestBuild.Controllers
{
  public class ResetTheApplicationController : ApiController
  {
    readonly DatabaseMaintainer maintainer;

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
