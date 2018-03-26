using System;
using Agiil.BDD.ServiceEndpoints;
using Agiil.Web.Services;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.WebApis.Builders;
using Agiil.Web.Models;

namespace Agiil.BDD.Actions
{
  public class LoadTheDataPackage : Performable
  {
    readonly string dataPackageTypeName;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} sets up the data package '{dataPackageTypeName}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Invoke.TheJsonWebService<LoadDataPackageService>().WithTheData(GetTheDataPackage()).AndVerifyItSucceeds());
    }

    SetupDataPackageRequest GetTheDataPackage()
      => new SetupDataPackageRequest() { PackageTypeName = dataPackageTypeName };

    LoadTheDataPackage(string dataPackageName)
    {
      if(dataPackageName == null)
        throw new ArgumentNullException(nameof(dataPackageName));
      this.dataPackageTypeName = dataPackageName;
    }

    public static IPerformable Type<TPackage>() where TPackage : IDataPackage
    {
      return Type(typeof(TPackage));
    }

    public static IPerformable Type(Type packageType)
    {
      if(packageType == null)
        throw new ArgumentNullException(nameof(packageType));
      
      return Named(packageType.Name);
    }

    public static IPerformable Named(string packageTypeName)
    {
      return new LoadTheDataPackage(packageTypeName);
    }
  }
}
