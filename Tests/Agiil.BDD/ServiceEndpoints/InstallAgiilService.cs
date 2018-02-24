using System;
using Agiil.Web.Controllers;

namespace Agiil.BDD.ServiceEndpoints
{
  public class InstallAgiilService : ControllerJsonServiceDescription
  {
    public override string ToString() => "the Agiil installer/reinstaller service";

    protected override string GetControllerName() => nameof(InstallAgiilController);
  }
}
