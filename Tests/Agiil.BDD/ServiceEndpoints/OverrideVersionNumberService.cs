using System;
using System.Net.Http;
using Agiil.Web.Controllers;

namespace Agiil.BDD.ServiceEndpoints
{
  public class OverrideVersionNumberService : ControllerJsonServiceDescription
  {
    public override HttpMethod HttpMethod => HttpMethod.Post;

    public override string Name => "the version number override service";

    protected override string GetControllerName() => nameof(OverrideVersionNumberController);
  }
}
