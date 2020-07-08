using System;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// A really simple implementation of <see cref="IGetsTargetEntityIdentity{TEntity, TObject}"/>, where the
    /// object passed is already an identity of the correct type.
    /// </summary>
    public class EntityIdentityProviderAdapter<TEntity> : IGetsTargetEntityIdentity<TEntity, IIdentity<TEntity>> where TEntity : IEntity
    {
        public IIdentity<TEntity> GetTargetEntityIdentity(IIdentity<TEntity> value) => value;
    }
}
