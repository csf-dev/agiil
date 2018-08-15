﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace Agiil.Bootstrap
{
  public class BulkRegistrationHelper
  {
    static readonly BulkRegistrationHelper singleton;
    readonly IGetsTypes concreteTypesProvider, openGenericTypesProvider;

    public void RegisterAll<T>(ContainerBuilder builder)
      => RegisterAllExcept<T>(builder, Enumerable.Empty<Type>());

    public void RegisterAllExcept<T>(ContainerBuilder builder, params Type[] typesNotToRegister)
      => RegisterAllExcept<T>(builder, (IEnumerable<Type>) typesNotToRegister);

    public void RegisterAllExcept<T>(ContainerBuilder builder, IEnumerable<Type> typesNotToRegister)
    {
      var concreteTypes = concreteTypesProvider
        .GetTypes<T>()
        .Except(typesNotToRegister ?? Enumerable.Empty<Type>())
        .ToArray();
      builder.RegisterTypes(concreteTypes).AsSelf().AsImplementedInterfaces();

      var openGenericTypes = openGenericTypesProvider
        .GetTypes<T>()
        .Except(typesNotToRegister ?? Enumerable.Empty<Type>())
        .ToArray();
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
