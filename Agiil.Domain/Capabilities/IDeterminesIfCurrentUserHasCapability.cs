using System;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// A service which gets a simple yes/no as to whether the current
    /// user has a specified capabiltiy for a specified entity.
    /// </summary>
    public interface IDeterminesIfCurrentUserHasCapability
    {
        bool DoesUserHaveCapability<TCapability, TEntity>(TCapability capability, IIdentity<TEntity> identity)
            where TEntity : IEntity
            where TCapability : struct, Enum;
    }
}
