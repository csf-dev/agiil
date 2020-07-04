using System;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public interface IGetsTargetEntityIdentityProvider
    {
        IGetsTargetEntityIdentity<TEntity, TObject> GetIdentityProvider<TEntity, TObject>() where TEntity : IEntity;
    }
}
