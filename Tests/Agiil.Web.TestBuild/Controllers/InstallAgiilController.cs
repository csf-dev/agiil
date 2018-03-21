using System;
using System.Web.Http;
using Agiil.Domain.Data;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class InstallAgiilController : ApiController
  {
    readonly IResetsDatabase dbResetter;

    public IHttpActionResult Post()
    {
      dbResetter.ResetDatabase();
      return Ok();
    }

    public InstallAgiilController(IResetsDatabase resetter)
    {
      if(resetter == null)
        throw new ArgumentNullException(nameof(resetter));

      this.dbResetter = resetter;
    }
  }
}
