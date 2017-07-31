using System;
using System.Web.Http;
using Agiil.Web.TestBuild.Services;

namespace Agiil.Web.TestBuild.Controllers
{
  public class ResetDatabaseController : ApiController
  {
    readonly DatabaseMaintainer maintainer;

    public IHttpActionResult Post()
    {
      maintainer.Reset();
      return Ok();
    }

    public ResetDatabaseController(DatabaseMaintainer maintainer)
    {
      if(maintainer == null)
        throw new ArgumentNullException(nameof(maintainer));

      this.maintainer = maintainer;
    }
  }
}
