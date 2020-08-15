using System;
using System.Collections.Generic;
using System.Linq;
using CSF.ORM;

namespace Agiil.Web.Services
{
  public class DataPackageLoader
  {
    readonly IEnumerable<Lazy<IDataPackage,DataPackageMetadata>> allPackages;

    public void LoadDataPackage(string typeName)
    {
      var package = SelectDataPackage(typeName);
      package.Load();
    }

    IDataPackage SelectDataPackage(string typeName)
    {
      var package = allPackages.FirstOrDefault(x => x.Metadata.PackageTypeName == typeName);

      if(package == null)
        throw new ArgumentException($"The data package '{typeName}' is not registered.",
                                    nameof(typeName));

      return package.Value;
    }

    public DataPackageLoader(IEnumerable<Lazy<IDataPackage,DataPackageMetadata>> allPackages)
    {
      this.allPackages = allPackages ?? throw new ArgumentNullException(nameof(allPackages));
    }
  }
}
