﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSF.ORM;

namespace Agiil.Web.Services
{
  public class DataPackageLoader
  {
    readonly IEnumerable<Lazy<IDataPackage,DataPackageMetadata>> allPackages;
    readonly IGetsTransaction transactionCreator;

    public void LoadDataPackage(string typeName)
    {
      var package = SelectDataPackage(typeName);

      using(var tran = transactionCreator.GetTransaction())
      {
        package.Load();
        tran.Commit();
      }
    }

    IDataPackage SelectDataPackage(string typeName)
    {
      var package = allPackages.FirstOrDefault(x => x.Metadata.PackageTypeName == typeName);

      if(package == null)
        throw new ArgumentException($"The data package '{typeName}' is not registered.",
                                    nameof(typeName));

      return package.Value;
    }

    public DataPackageLoader(IEnumerable<Lazy<IDataPackage,DataPackageMetadata>> allPackages,
                             IGetsTransaction transactionCreator)
    {
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(allPackages == null)
        throw new ArgumentNullException(nameof(allPackages));
      
      this.allPackages = allPackages;
      this.transactionCreator = transactionCreator;
    }
  }
}
