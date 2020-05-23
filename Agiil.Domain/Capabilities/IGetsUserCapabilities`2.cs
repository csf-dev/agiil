using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public interface IGetsUserCapabilities<TEntity, TCapability>
        where TEntity : IEntity
        where TCapability : Enum
    {
        TCapability GetCapabilities(IIdentity<User> user, IIdentity<TEntity> targetEntity);
    }
}
