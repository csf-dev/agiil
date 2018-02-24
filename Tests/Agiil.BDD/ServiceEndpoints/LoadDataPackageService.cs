using System;
using Agiil.Web.Controllers;
using Agiil.Web.Models;

namespace Agiil.BDD.ServiceEndpoints
{
  public class LoadDataPackageService : ControllerJsonServiceDescription
  {
    public override string ToString() => "the data-package loading service";

    protected override string GetControllerName() => nameof(SetupDataPackageController);

    public LoadDataPackageService(string dataPackageTypeName)
      : base(requestPayload: new SetupDataPackageRequest { PackageTypeName = dataPackageTypeName }) {}
  }
}
