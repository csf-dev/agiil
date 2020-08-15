using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Agiil.Web.Services;
using Agiil.Bootstrap.Specifications;
using CSF.Specifications;
using CSF.Reflection;

namespace Agiil.Web.Bootstrap
{
    public class DataPackagesModule : Autofac.Module
    {
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
              .And(new DerivesFromSpecification(typeof(IDataPackage)));

            return new TestBuildExportedTypesProvider()
                      .GetTypes()
                      .Where(isDataPackage)
                      .ToArray();
        }
    }
}
