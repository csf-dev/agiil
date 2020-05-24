using System;
using System.Reflection;

namespace Agiil.Domain.Capabilities
{
    public class CapabilityEnforcementProvider : IGetsWhetherCapabilitiesShouldBeEnforcedForType
    {
        public bool ShouldCapabilitiesBeEnforced(Type type)
        {
            if(type == null) return false;
            if(!type.IsInterface) return false;

            return (type.GetCustomAttribute<EnforceCapabilitiesAttribute>() != null);
        }
    }
}
