using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Web.Services
{
  public class DataPackageLoader
  {
    readonly IEnumerable<Lazy<IDataPackage,DataPackageMetadata>> allPackages;

    public void LoadDataPackage(string typeName)
    {
      var package = allPackages.FirstOrDefault(x => x.Metadata.PackageTypeName == typeName);

      if(package == null)
        throw new ArgumentException($"The data package '{typeName}' is not registered.",
                                    nameof(typeName));

      package.Value.Load();
    }

    public DataPackageLoader(IEnumerable<Lazy<IDataPackage,DataPackageMetadata>> allPackages)
    {
      if(allPackages == null)
        throw new ArgumentNullException(nameof(allPackages));
      
      this.allPackages = allPackages;
    }
  }
}
