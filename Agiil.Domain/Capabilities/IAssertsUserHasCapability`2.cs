using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Domain.Capabilities
{
    public interface IAssertsUserHasCapability<TEntity,TCapability>
        where TEntity : IEntity
        where TCapability : struct
    {
        void AssertUserHasCapability(IIdentity<User> user, IIdentity<TEntity> targetEntity, TCapability requiredCapability);
    }
}
