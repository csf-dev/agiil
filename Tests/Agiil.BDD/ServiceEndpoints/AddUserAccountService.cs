using System;
using System.Net.Http;
using Agiil.Web.Controllers;
using CSF.Screenplay.WebApis;

namespace Agiil.BDD.ServiceEndpoints
{
  public class AddUserAccountService : ControllerJsonServiceDescription
  {
    public override HttpMethod HttpMethod => HttpMethod.Post;

    public override string Name => "the 'add a user account' service";

    protected override string GetControllerName() => nameof(AddUserController);
  }
}
