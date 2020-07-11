using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// A non-generic service which gets a user's capabilities.
    /// </summary>
    public interface IGetsUserCapabilities
    {
        TCapability GetCapabilities<TEntity, TCapability>(IIdentity<User> userIdentity, IIdentity<TEntity> targetEntity)
            where TEntity : IEntity
            where TCapability : struct, Enum;
    }
}
