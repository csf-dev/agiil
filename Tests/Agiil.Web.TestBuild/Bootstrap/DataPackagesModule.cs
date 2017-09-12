using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Agiil.Web.Services.DataPackages;
using Autofac;
using Agiil.Web.Services;

namespace Agiil.Web.Bootstrap
{
  public class DataPackagesModule : Autofac.Module
  {
    static readonly Type
      NamespaceMarker = typeof(IDataPackagesNamespaceMarker),
      DataPackageInterface = typeof(IDataPackage);

    string DataPackagesNamespace => NamespaceMarker.Namespace;

    protected override void Load(ContainerBuilder builder)
    {
      var packageTypes = GetDataPackageTypes();

      foreach(var packageType in packageTypes)
      {
        builder
          .RegisterType(packageType)
          .As<IDataPackage>()
          .WithMetadata<DataPackageMetadata>(config => {
            config.For(x => x.PackageTypeName, packageType.Name);
          });
      }
    }

    IEnumerable<Type> GetDataPackageTypes()
    {
      return (from type in Assembly.GetExecutingAssembly().GetExportedTypes()
              where
                type.IsClass
                && !type.IsAbstract
                && DataPackageInterface.IsAssignableFrom(type)
                && type.Namespace == DataPackagesNamespace
             select type)
        .ToArray();
    }
  }
}
