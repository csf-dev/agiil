using System;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// Implement this interface to get entity identities from various objects in the app domain.
    /// </summary>
    public interface IGetsTargetEntityIdentity<TEntity,in TObject> where TEntity : IEntity
    {
        /// <summary>
        /// Gets the identity of the target entity from a specified value.
        /// </summary>
        /// <returns>The target entity identity.</returns>
        /// <param name="value">A value which can (with some analysis) indicate the identity of a target entity, which may have capabilities.</param>
        IIdentity<TEntity> GetTargetEntityIdentity(TObject value);
    }
}
