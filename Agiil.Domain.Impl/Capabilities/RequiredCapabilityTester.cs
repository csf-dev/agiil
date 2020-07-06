using System;
using Agiil.Domain.Auth;
using CSF.Entities;
using CSF;
using System.Linq;

namespace Agiil.Domain.Capabilities
{
    public class RequiredCapabilityTester<TEntity,TCapability> : IAssertsUserHasCapability<TEntity, TCapability>
        where TEntity : IEntity
        where TCapability : struct
    {
        readonly IGetsUserCapabilities<TEntity, TCapability> capabilitiesProvider;

        public void AssertUserHasCapability(IIdentity<User> user, IIdentity<TEntity> targetEntity, TCapability requiredCapability)
        {
            // Once https://github.com/csf-dev/CSF.Utils/issues/127 is resolved, convert this to an extension method call.
            EnumFlagsExtensions.AssertIsFlagsEnum(typeof(TCapability));

            var actualCapability = capabilitiesProvider.GetCapabilities(user, targetEntity);

            var requiredList = requiredCapability.GetBase2FlagValues().ToList();
            var actualList = actualCapability.GetBase2FlagValues().ToList();

            if(requiredList.Intersect(actualList).Count() == requiredList.Count()) return;

            var message = $@"The user {user} must have the capability {requiredCapability} for {targetEntity},
but their actual capabilities were {(Equals(actualCapability,default(TCapability))? "<none>" : actualCapability.ToString())}.";

            throw new UserMustHaveCapabilityException(message,
                                                      user,
                                                      targetEntity,
                                                      requiredCapability.ToString(),
                                                      actualCapability.ToString());
        }

        public RequiredCapabilityTester(IGetsUserCapabilities<TEntity, TCapability> capabilitiesProvider)
        {
            this.capabilitiesProvider = capabilitiesProvider ?? throw new ArgumentNullException(nameof(capabilitiesProvider));
        }
    }
}
