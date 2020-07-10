using System;
using System.Linq;
using CSF;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public class CapabilitiesForCurrentUserProvider : IDeterminesIfCurrentUserHasCapability
    {
        readonly IGetsCurrentCapabilityUser userReader;
        readonly IGetsUserCapabilities capabilitiesProvider;

        public bool DoesUserHaveCapability<TCapability, TEntity>(TCapability capability, IIdentity<TEntity> identity)
            where TEntity : IEntity
            where TCapability : struct, Enum
        {
            var user = userReader.GetCurrentCapabilityUser();
            var actualCapabilities = capabilitiesProvider.GetCapabilities<TEntity, TCapability>(user, identity);

            var requiredList = capability.GetBase2FlagValues().ToList();
            var actualList = actualCapabilities.GetBase2FlagValues().ToList();

            var result = requiredList.Intersect(actualList).Count() == requiredList.Count();
            return result;
        }

        public CapabilitiesForCurrentUserProvider(IGetsCurrentCapabilityUser userReader,
                                                  IGetsUserCapabilities capabilitiesProvider)
        {
            this.userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
            this.capabilitiesProvider = capabilitiesProvider ?? throw new ArgumentNullException(nameof(capabilitiesProvider));
        }
    }
}
