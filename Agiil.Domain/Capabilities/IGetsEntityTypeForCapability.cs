using System;
namespace Agiil.Domain.Capabilities
{
    public interface IGetsEntityTypeForCapability
    {
        Type GetEntityType(object capability);
    }
}
