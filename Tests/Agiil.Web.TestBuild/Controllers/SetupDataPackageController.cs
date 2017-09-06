using System;
using System.Web.Http;
using Agiil.Domain.Auth;
using Agiil.Web.Models;
using Agiil.Web.Services;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
  public class SetupDataPackageController : ApiController
  {
    readonly DataPackageLoader loader;
    readonly IOverridesCurrentLogin loginOverride;

    public IHttpActionResult Post(SetupDataPackageRequest request)
    {
      loginOverride.OverrideLogin(AdminUser.Username);
      loader.LoadDataPackage(request.PackageTypeName);
      return Ok();
    }

    public SetupDataPackageController(DataPackageLoader loader,
                                      IOverridesCurrentLogin loginOverride)
    {
      if(loader == null)
        throw new ArgumentNullException(nameof(loader));
      if(loginOverride == null)
        throw new ArgumentNullException(nameof(loginOverride));
      
      this.loader = loader;
      this.loginOverride = loginOverride;
    }
  }
}
