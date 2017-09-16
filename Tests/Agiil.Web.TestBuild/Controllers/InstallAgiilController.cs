using System;
using System.Web.Http;
using Agiil.Data.Maintenance;
using Agiil.Web.Services;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class InstallAgiilController : ApiController
  {
    readonly IDatabaseResetter dbResetter;

    public IHttpActionResult Post()
    {
      dbResetter.ResetDatabase();
      return Ok();
    }

    public InstallAgiilController(IDatabaseResetter resetter)
    {
      if(resetter == null)
        throw new ArgumentNullException(nameof(resetter));

      this.dbResetter = resetter;
    }
  }
}
