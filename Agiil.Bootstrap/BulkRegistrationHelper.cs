using System;
using System.Linq;
using Autofac;

namespace Agiil.Bootstrap
{
  public class BulkRegistrationHelper
  {
    static readonly BulkRegistrationHelper singleton;
    readonly IGetsTypes concreteTypesProvider, openGenericTypesProvider;

    public void RegisterAll<T>(ContainerBuilder builder)
    {
      var concreteTypes = concreteTypesProvider.GetTypes<T>().ToArray();
      builder.RegisterTypes(concreteTypes).AsSelf().AsImplementedInterfaces();

      var openGenericTypes = openGenericTypesProvider.GetTypes<T>().ToArray();
      foreach(var type in openGenericTypes)
        builder.RegisterGeneric(type).AsSelf();
    }

    public BulkRegistrationHelper(IGetsTypes concreteTypesProvider = null,
                                  IGetsTypes openGenericTypesProvider = null)
    {
      this.concreteTypesProvider = concreteTypesProvider ?? new ConcreteTypesInAssemblyOfMarkerProvider();
      this.openGenericTypesProvider = openGenericTypesProvider ?? new OpenGenericTypesInAssemblyOfMarkerProvider();
    }

    static BulkRegistrationHelper()
    {
      singleton = new BulkRegistrationHelper();
    }

    public static BulkRegistrationHelper Default => singleton;
  }
}
