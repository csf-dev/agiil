using System;
using Agiil.Web.Controllers;
using CSF.Screenplay.JsonApis;

namespace Agiil.BDD.ServiceEndpoints
{
  public class AddUserAccountService : ControllerJsonServiceDescription
  {
    public override string ToString() => "the 'add a user account' service";

    protected override string GetControllerName() => nameof(AddUserController);

    public AddUserAccountService(string username, string password)
      : base(requestPayload: new { username, password }) {}
  }
}
