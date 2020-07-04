using System;
using System.Reflection;
using CSF.Entities;
using CSF.Reflection;

namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// This class uses the factory service <see cref="IGetsTargetEntityIdentityProvider"/> to get an
    /// <see cref="IGetsTargetEntityIdentity{TEntity, TObject}"/>.  It then uses that to get the identity.
    /// </summary>
    public class EntityIdentityProvider : IGetsTargetEntityIdentity
    {
        static readonly MethodInfo GenericGetMethod
            = Reflect.Method<EntityIdentityProvider>(x => x.GetTargetEntityIdentity<IEntity, object>(null))
                .GetGenericMethodDefinition();

        readonly IGetsTargetEntityIdentityProvider providerFactory;

        public IIdentity<TEntity> GetTargetEntityIdentity<TEntity>(object value) where TEntity : IEntity
        {
            if(value == null) return null;
            var valueType = value.GetType();

            var getMethod = GenericGetMethod.MakeGenericMethod(typeof(TEntity), valueType);
            return (IIdentity<TEntity>) getMethod.Invoke(this, new object[] { value });
        }

        IIdentity<TEntity> GetTargetEntityIdentity<TEntity, TValue>(TValue value) where TEntity : IEntity
        {
            var provider = providerFactory.GetIdentityProvider<TEntity, TValue>();
            return provider.GetTargetEntityIdentity(value);
        }

        public EntityIdentityProvider(IGetsTargetEntityIdentityProvider providerFactory)
        {
            this.providerFactory = providerFactory ?? throw new System.ArgumentNullException(nameof(providerFactory));
        }
    }
}
