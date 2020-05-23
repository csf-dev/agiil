using System;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public interface IGetsTypedCapabilityTester
    {
        IAssertsUserHasCapability<TEntity, TCapability> GetCapabilityTester<TEntity, TCapability>()
            where TEntity : IEntity
            where TCapability : Enum;
    }
}
