using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Agiil.Domain;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using Agiil.Tests.Attributes;
using Autofac;
using Autofac.Core;
using CSF.Reflection;
using NUnit.Framework;

namespace Agiil.Tests.Capabilities
{
    [TestFixture]
    public class AllDecoratedInterfacesMustHaveValueProvidersTest
    {
        [Test, AutoMoqData, WithDi]
        public void Verify_that_all_interfaces_which_enforce_capabilities_can_get_a_related_entity_type([FromDi] Lazy<IGetsTargetEntityIdentityProvider> factory,
                                                                                                        [FromDi] Lazy<IGetsEntityTypeForCapability> entityTypeProvider)
        {
            var capabilityTypesWithMissingEntityTypes = (from method in GetAllMethodsWhichHaveCapabilityEnforcement()
                                                         let tester = new MethodCapabilitiesTestingHelper(factory.Value, entityTypeProvider.Value)
                                                         from capabilityType in tester.GetCapabilityTypesWithMissingEntityTypes(method)
                                                         select capabilityType)
                .ToList();

            Assert.That(capabilityTypesWithMissingEntityTypes, Is.Empty, $@"The following capability types cannot be mapped to entity types using {nameof(IGetsEntityTypeForCapability)}:
{String.Join("\n", capabilityTypesWithMissingEntityTypes.Select(x => $"* {x.FullName}"))}");
        }

        [Test, AutoMoqData, WithDi]
        public void Verify_that_all_interfaces_which_enforce_capabilities_can_get_an_entity_identity([FromDi] Lazy<IGetsTargetEntityIdentityProvider> factory,
                                                                                                     [FromDi] Lazy<IGetsEntityTypeForCapability> entityTypeProvider)
        {
            var missingInfo = (from method in GetAllMethodsWhichHaveCapabilityEnforcement()
                               let tester = new MethodCapabilitiesTestingHelper(factory.Value, entityTypeProvider.Value)
                               from action in tester.GetActionsWithMissingIdentifierProviders(method)
                               select action)
                .ToList();

            Assert.That(missingInfo, Is.Empty, GetMissingIdentityProvidersFailureMessage(missingInfo));
        }

        [Test, AutoMoqData, WithDi]
        public void Verify_that_all_capability_and_entity_type_pairs_have_a_capabilities_provider([FromDi] Lazy<ILifetimeScope> scope,
                                                                                                  [FromDi] Lazy<IGetsTargetEntityIdentityProvider> factory,
                                                                                                  [FromDi] Lazy<IGetsEntityTypeForCapability> entityTypeProvider)
        {
            var requiredProviderTypes = (from method in GetAllMethodsWhichHaveCapabilityEnforcement()
                                         let tester = new MethodCapabilitiesTestingHelper(factory.Value, entityTypeProvider.Value)
                                         from typePair in tester.GetCapabilityAndEntityTypes(method)
                                         let providerType = typeof(IGetsUserCapabilities<,>).MakeGenericType(typePair.Item2, typePair.Item1)
                                         select providerType)
                .Distinct()
                .ToList();

            var missingProviderTypes = requiredProviderTypes
                .Select(x => {
                    try
                    {
                        var provider = scope.Value.Resolve(x);
                        if(provider != null) return null;
                        return x;
                    }
                    catch(DependencyResolutionException)
                    {
                        return x;
                    }
                })
                .Where(x => x != null)
                .ToList();

            Assert.That(missingProviderTypes, Is.Empty, $@"The following capability provider types could not be resolved, perhaps they are missing?
{String.Join("\n", missingProviderTypes.Select(x => $"* {x.Name.Split('`')[0]}<{x.GetGenericArguments()[0].Name},{x.GetGenericArguments()[1].Name}>"))}");
        }

        string GetMissingIdentityProvidersFailureMessage(IEnumerable<ActionWithMissingIdentifierProvider> actions)
        {
            var builder = new StringBuilder();
            builder.AppendLine("One or more types in the app require identity providers which are missing.");

            foreach(var action in actions)
            {
                builder.AppendLine();
                builder.AppendLine($"       Action name: {action.Method.DeclaringType.Name}.{action.Method.Name}");
                builder.AppendLine($"Provider interface: {nameof(IGetsTargetEntityIdentity<User,object>)}<{action.EntityType.Name},{action.ParameterType.Name}>");
            }

            return builder.ToString();
        }

        List<MethodInfo> GetAllMethodsWhichHaveCapabilityEnforcement()
        {
            var domainTypes = new DomainAssemblyMarker().Assembly.GetExportedTypes();
            var implTypes = new DomainImplAssemblyMarker().Assembly.GetExportedTypes();
            var allTypes = domainTypes.Union(implTypes).ToList();

            return (from type in allTypes
                    where type.GetCustomAttribute<EnforceCapabilitiesAttribute>() != null
                    from method in type.GetMethods()
                    from parameter in method.GetParameters()
                    where parameter.GetCustomAttribute<RequireCapabilityAttribute>() != null
                    select method)
                .ToList();
        }

        #region contained type with assembly-scanning logic

        class MethodCapabilitiesTestingHelper
        {
            static readonly MethodInfo
                OpenGenericResolveMethod = Reflect.Method<IGetsTargetEntityIdentityProvider>(x => x.GetIdentityProvider<User, object>())
                                                  .GetGenericMethodDefinition();

            readonly IGetsTargetEntityIdentityProvider factory;
            readonly IGetsEntityTypeForCapability entityTypeProvider;

            public IEnumerable<ActionWithMissingIdentifierProvider> GetActionsWithMissingIdentifierProviders(MethodInfo method)
            {
                return method.GetParameters()
                    .Select(x => GetActionsWithMissingIdentifierProviders(method, x))
                    .Where(x => x != null)
                    .ToList();
            }

            public IEnumerable<Type> GetCapabilityTypesWithMissingEntityTypes(MethodInfo method)
            {
                return (from param in method.GetParameters()
                        let attr = param.GetCustomAttribute<RequireCapabilityAttribute>()
                        where
                            attr != null
                            && GetEntityType(param) == null
                        select attr.RequiredCapability.GetType())
                    .Distinct()
                    .ToList();
            }

            public IEnumerable<(Type,Type)> GetCapabilityAndEntityTypes(MethodInfo method)
            {
                return (from param in method.GetParameters()
                        let attr = param.GetCustomAttribute<RequireCapabilityAttribute>()
                        where attr != null
                        let entityType = GetEntityType(param)
                        where entityType != null
                        select (attr.RequiredCapability.GetType(), entityType))
                    .Distinct()
                    .ToList();
            }

            ActionWithMissingIdentifierProvider GetActionsWithMissingIdentifierProviders(MethodInfo method, ParameterInfo param)
            {
                var entityType = GetEntityType(param);
                if(entityType == null) return null;

                if(CanEntityIdentityProviderBeResolved(entityType, param.ParameterType)) return null;

                return new ActionWithMissingIdentifierProvider {
                    Method = method,
                    EntityType = entityType,
                    ParameterType = param.ParameterType,
                };
            }

            Type GetEntityType(ParameterInfo param)
            {
                var capabilityAttribute = param.GetCustomAttribute<RequireCapabilityAttribute>();
                if(capabilityAttribute == null) return null;

                return entityTypeProvider.GetEntityType(capabilityAttribute.RequiredCapability);
            }

            bool CanEntityIdentityProviderBeResolved(Type entityType, Type parameterType)
            {
                var resolver = OpenGenericResolveMethod.MakeGenericMethod(entityType, parameterType);
                try
                {
                    return resolver.Invoke(factory, new object[0]) != null;
                }
                catch(TargetInvocationException tie)
                {
                    if(tie.InnerException is IdentityProviderNotAvailableException)
                        return false;
                    throw;
                }
                catch(IdentityProviderNotAvailableException)
                {
                    return false;
                }
            }

            public MethodCapabilitiesTestingHelper(IGetsTargetEntityIdentityProvider factory,
                                                          IGetsEntityTypeForCapability entityTypeProvider)
            {
                this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
                this.entityTypeProvider = entityTypeProvider ?? throw new ArgumentNullException(nameof(entityTypeProvider));
            }
        }

        #endregion

        class ActionWithMissingIdentifierProvider
        {
            public MethodInfo Method { get; set; }

            public Type ParameterType { get; set; }

            public Type EntityType { get; set; }
        }
    }
}
