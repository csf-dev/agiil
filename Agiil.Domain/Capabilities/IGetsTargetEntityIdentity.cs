using System;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public interface IGetsTargetEntityIdentity
    {
        /// <summary>
        /// Gets the identity of the target entity from a specified value.
        /// </summary>
        /// <returns>The target entity identity.</returns>
        /// <param name="value">A value which can (with some analysis) indicate the identity of a target entity, which may have capabilities.</param>
        /// <typeparam name="TEntity">The type of the target entity.</typeparam>
        IIdentity<TEntity> GetTargetEntityIdentity<TEntity>(object value) where TEntity : IEntity;
    }
}
