using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Agiil.Web.Services.DataPackages;
using Autofac;
using Agiil.Web.Services;
using Agiil.Bootstrap;
using Agiil.Bootstrap.Specifications;
using CSF.Data.Specifications;

namespace Agiil.Web.Bootstrap
{
  public class DataPackagesModule : Autofac.Module
  {
    readonly IGetsTypes typeProvider;

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
      var isDataPackage = new IsConcreteSpecification()
        .And(new ImplementsSpecification<IDataPackage>());
      
      return typeProvider.GetTypes<IDataPackagesNamespaceMarker>()
                         .Where(isDataPackage)
                         .ToArray();
    }

    public DataPackagesModule() : this(null) {}

    public DataPackagesModule(IGetsTypes typeProvider)
    {
      this.typeProvider = typeProvider ?? new ConcreteTypesInAssemblyOfMarkerProvider();
    }
  }
}
