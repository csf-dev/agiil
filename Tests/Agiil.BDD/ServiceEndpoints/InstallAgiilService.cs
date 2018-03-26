using System;
using System.Net.Http;
using Agiil.Web.Controllers;

namespace Agiil.BDD.ServiceEndpoints
{
  public class InstallAgiilService : ControllerJsonServiceDescription
  {
    public override HttpMethod HttpMethod => HttpMethod.Post;

    public override string Name => "the Agiil installer/reinstaller service";

    protected override string GetControllerName() => nameof(InstallAgiilController);
  }
}
