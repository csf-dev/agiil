using System;
using System.Net.Http;
using Agiil.Web.Controllers;
using Agiil.Web.Models;

namespace Agiil.BDD.ServiceEndpoints
{
  public class LoadDataPackageService : ControllerJsonServiceDescription
  {
    public override HttpMethod HttpMethod => HttpMethod.Post;

    public override string Name => "the data-package loading service";

    protected override string GetControllerName() => nameof(SetupDataPackageController);
  }
}
