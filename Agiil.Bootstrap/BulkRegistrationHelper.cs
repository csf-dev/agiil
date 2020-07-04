using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Bootstrap.Capabilities;
using Agiil.Domain.Capabilities;
using Autofac;
using Autofac.Extras.DynamicProxy;
using CSF.Specifications;

namespace Agiil.Bootstrap
{
    public class BulkRegistrationHelper
    {
        static readonly BulkRegistrationHelper singleton;
        readonly IGetsTypes concreteTypesProvider, openGenericTypesProvider;

        public void RegisterAll<T>(ContainerBuilder builder, bool enableInterception = true)
          => RegisterAllExcept<T>(builder, Enumerable.Empty<Type>(), enableInterception);

        public void RegisterAllExcept<T>(ContainerBuilder builder,
                                         IEnumerable<Type> typesNotToRegister,
                                         bool enableInterception = true)
        {
            var concreteTypes = concreteTypesProvider
              .GetTypes<T>()
              .Except(typesNotToRegister ?? Enumerable.Empty<Type>())
              .ToArray();
    
            builder.RegisterTypes(concreteTypes)
                .AsSelf()
                .AsImplementedInterfaces();

            if(enableInterception)
            {
                var shouldInterceptSpec = new CapabilityEnforcementSpec();
                var typesToIntercept = (from type in concreteTypes
                                        from @interface in type.GetInterfaces()
                                        where shouldInterceptSpec.Matches(@interface)
                                        select type)
                    .ToArray();

                builder.RegisterTypes(typesToIntercept)
                    .AsImplementedInterfaces()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(CapabilitiesEnforcingInterceptor));
            }

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
