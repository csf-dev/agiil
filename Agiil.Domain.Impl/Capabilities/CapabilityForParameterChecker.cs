using System;
using System.Reflection;
using CSF.Entities;
using CSF.Reflection;

namespace Agiil.Domain.Capabilities
{
    public class CapabilityForParameterChecker : IAssertsUserHasCapability
    {
        // This fake enum is used only as a throwaway placeholder in static reflection, below.
        // Although it's used as a generic type parameter, we throw that generic type param
        // away with .GetGenericMethodDefinition().
        enum FakeEnum { }

        static readonly MethodInfo OpenGenericAssertMethod = Reflect
            .Method<CapabilityForParameterChecker>(x => x.AssertCurrentUserHasCapability<IEntity, FakeEnum>(null, 0, null))
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

            method.Invoke(this, new[] { assertionSpec.ParameterValue, requiredCapability, assertionSpec.ActionName });
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

        void AssertCurrentUserHasCapability<TEntity,TCapability>(object entityProviderValue, TCapability requiredCapability, string actionName)
            where TEntity : IEntity
            where TCapability : struct,Enum
        {
            var targetEntity = targetEntityProvider.GetTargetEntityIdentity<TEntity>(entityProviderValue);
            if(targetEntity == null) return;

            var tester = testerFactory.GetCapabilityTester<TEntity, TCapability>();

            try
            {
                tester.AssertUserHasCapability(userProvider.GetCurrentCapabilityUser(),
                                               targetEntity,
                                               requiredCapability);
            }
            catch(UserMustHaveCapabilityException e)
            {
                // The reason for the catch-and-rethrow is to add the 'action name' information to the exception.
                throw new UserMustHaveCapabilityException($"{e.Message}\nAction: {actionName}",
                                                          e,
                                                          e.UserIdentity,
                                                          e.EntityIdentity,
                                                          e.RequiredCapabilities,
                                                          e.ActualCapabilities,
                                                          actionName);
            }
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
