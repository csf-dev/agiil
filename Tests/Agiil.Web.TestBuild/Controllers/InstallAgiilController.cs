using System;
using System.Web.Http;
using Agiil.Web.Services;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class InstallAgiilController : ApiController
  {
    readonly DatabaseMaintainer maintainer;

    public IHttpActionResult Post()
    {
      maintainer.Reset();
      return Ok();
    }

    public InstallAgiilController(DatabaseMaintainer maintainer)
    {
      if(maintainer == null)
        throw new ArgumentNullException(nameof(maintainer));

      this.maintainer = maintainer;
    }
  }
}
