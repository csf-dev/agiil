using System;
using System.Reflection;
using CSF.Entities;
using CSF.Reflection;

namespace Agiil.Domain.Capabilities
{
    public class CapabilityForParameterChecker : IAssertsUserHasCapability
    {
        static readonly MethodInfo OpenGenericAssertMethod = Reflect
            .Method<CapabilityForParameterChecker>(x => x.AssertCurrentUserHasCapability<IEntity, Enum>(null, null))
            .GetGenericMethodDefinition();

        readonly IGetsTypedCapabilityTester testerFactory;
        readonly IGetsEntityTypeForCapability entityTypeProvider;
        readonly IGetsCurrentCapabilityUser userProvider;
        readonly IGetsTargetEntityIdentity targetEntityProvider;

        public void AssertCurrentUserHasCapability(CapabilitiesAssertionSpec assertionSpec)
        {
            if(assertionSpec == null)
                throw new ArgumentNullException(nameof(assertionSpec));

            var capabilityType = GetCapabilityType(assertionSpec.CapabilityAttribute);
            var requiredCapability = assertionSpec.CapabilityAttribute.RequiredCapability;
            var entityType = entityTypeProvider.GetEntityType(requiredCapability);

            // Need to use reflection to get into the generic method from a non-generic one.
            // The trade-off is worth it IMO, because it allows the rest of the capabilities stack 'from here downwards' to be strongly-typed.
            var method = OpenGenericAssertMethod.MakeGenericMethod(entityType, capabilityType);

            method.Invoke(this, new[] { assertionSpec.ParameterValue, requiredCapability });
        }

        Type GetCapabilityType(RequireCapabilityAttribute capabilityAttribute)
        {
            var capabilityType = capabilityAttribute.RequiredCapability.GetType();
            if(!capabilityType.IsEnum)
            {
                throw new ArgumentException($"The capability indicated by {nameof(capabilityAttribute)}.{nameof(RequireCapabilityAttribute.RequiredCapability)} " +
                                            $"must derive from {nameof(Enum)}, but type {capabilityType.Name} does not.",
                                            nameof(capabilityAttribute));
            }

            return capabilityType;
        }

        void AssertCurrentUserHasCapability<TEntity,TCapability>(object entityProviderValue, TCapability requiredCapability)
            where TEntity : IEntity
            where TCapability : Enum
        {
            var targetEntity = targetEntityProvider.GetTargetEntityIdentity<TEntity>(entityProviderValue);
            if(targetEntity == null) return;

            var tester = testerFactory.GetCapabilityTester<TEntity, TCapability>();
            tester.AssertUserHasCapability(userProvider.GetCurrentCapabilityUser(),
                                           targetEntity,
                                           requiredCapability);
        }

        public CapabilityForParameterChecker(IGetsTypedCapabilityTester testerFactory,
                                             IGetsEntityTypeForCapability entityTypeProvider,
                                             IGetsCurrentCapabilityUser userProvider,
                                             IGetsTargetEntityIdentity targetEntityProvider)
        {
            this.testerFactory = testerFactory ?? throw new ArgumentNullException(nameof(testerFactory));
            this.entityTypeProvider = entityTypeProvider ?? throw new ArgumentNullException(nameof(entityTypeProvider));
            this.userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            this.targetEntityProvider = targetEntityProvider ?? throw new ArgumentNullException(nameof(targetEntityProvider));
        }
    }
}
