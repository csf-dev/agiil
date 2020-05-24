using System;
namespace Agiil.Domain.Capabilities
{
    public interface IGetsWhetherCapabilitiesShouldBeEnforcedForType
    {
        bool ShouldCapabilitiesBeEnforced(Type type);
    }
}
