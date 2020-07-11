using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// Implement this interface to get the capabilities possessed by a specified user, for a specified
    /// entity type.
    /// </summary>
    public interface IGetsUserCapabilities<TEntity, TCapability>
        where TEntity : IEntity
        where TCapability : struct, Enum
    {
        TCapability GetCapabilities(IIdentity<User> userIdentity, IIdentity<TEntity> targetEntity);
    }
}
