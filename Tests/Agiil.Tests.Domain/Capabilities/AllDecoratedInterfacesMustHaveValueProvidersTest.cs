using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Agiil.Domain;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using Agiil.Tests.Attributes;
using CSF.Reflection;
using NUnit.Framework;

namespace Agiil.Tests.Capabilities
{
    [TestFixture]
    public class AllDecoratedInterfacesMustHaveValueProvidersTest
    {
        [Test, AutoMoqData, WithDi]
        public void Verify_that_all_interfaces_which_enforce_capabilities_can_get_an_entity_identity([FromDi] Lazy<IGetsTargetEntityIdentityProvider> factory,
                                                                                                     [FromDi] Lazy<IGetsEntityTypeForCapability> entityTypeProvider)
        {
            var missingInfo = (from method in GetAllMethodsWhichHaveCapabilityEnforcement()
                               let tester = new MethodCapabilityIdentityResolverTester(factory.Value, entityTypeProvider.Value)
                               from action in tester.GetActionsWithMissingIdentifierProviders(method)
                               select action)
                .ToList();

            Assert.That(missingInfo, Is.Empty, GetFailureMessage(missingInfo));
        }

        string GetFailureMessage(IEnumerable<ActionWithMissingIdentifierProvider> actions)
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

        class MethodCapabilityIdentityResolverTester
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

            ActionWithMissingIdentifierProvider GetActionsWithMissingIdentifierProviders(MethodInfo method, ParameterInfo param)
            {
                var capabilityAttribute = param.GetCustomAttribute<RequireCapabilityAttribute>();
                if(capabilityAttribute == null) return null;

                var entityType = entityTypeProvider.GetEntityType(capabilityAttribute.RequiredCapability);
                if(entityType == null)
                    throw new InvalidOperationException($"Implementation of {nameof(IGetsEntityTypeForCapability)} cannot get an entity type for capability type {capabilityAttribute.RequiredCapability.GetType().Name}");

                if(CanEntityIdentityProviderBeResolved(entityType, param.ParameterType)) return null;

                return new ActionWithMissingIdentifierProvider {
                    Method = method,
                    EntityType = entityType,
                    ParameterType = param.ParameterType,
                };
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

            public MethodCapabilityIdentityResolverTester(IGetsTargetEntityIdentityProvider factory,
                                                          IGetsEntityTypeForCapability entityTypeProvider)
            {
                this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
                this.entityTypeProvider = entityTypeProvider ?? throw new ArgumentNullException(nameof(entityTypeProvider));
            }
        }

        class ActionWithMissingIdentifierProvider
        {
            public MethodInfo Method { get; set; }

            public Type ParameterType { get; set; }

            public Type EntityType { get; set; }
        }
    }
}
