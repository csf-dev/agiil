using System.Reflection;
using Agiil.Domain.Capabilities;
using Autofac;
using CSF.Entities;
using CSF.Reflection;

namespace Agiil.Bootstrap.Capabilities
{
    public class TargetEntityIdentityProvidersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EntityIdentityProvider>()
                .AsSelf()
                .AsImplementedInterfaces();
        }

        /// <summary>
        /// This class acts as an adapter for a dynamically-resolved implementation of the generic interface
        /// <see cref="IGetsTargetEntityIdentity{TEntity, TObject}"/>.
        /// </summary>
        public class EntityIdentityProvider : IGetsTargetEntityIdentity
        {
            static readonly MethodInfo GenericGetMethod
                = Reflect.Method<EntityIdentityProvider>(x => x.GetTargetEntityIdentity<IEntity, object>(null))
                    .GetGenericMethodDefinition();

            readonly ILifetimeScope scope;

            public IIdentity<TEntity> GetTargetEntityIdentity<TEntity>(object value) where TEntity : IEntity
            {
                if(value == null) return null;
                if(value is IIdentity<TEntity> identityValue) return identityValue;

                var valueType = value.GetType();

                var getMethod = GenericGetMethod.MakeGenericMethod(typeof(TEntity), valueType);
                return (IIdentity<TEntity>) getMethod.Invoke(this, new object[] { value });
            }

            IIdentity<TEntity> GetTargetEntityIdentity<TEntity, TValue>(TValue value) where TEntity : IEntity
            {
                try
                {
                    return scope.Resolve<IGetsTargetEntityIdentity<TEntity, TValue>>().GetTargetEntityIdentity(value);
                }
                catch(Autofac.Core.Registration.ComponentNotRegisteredException ex)
                {
                    throw new IdentityProviderNotAvailableException($@"No service could be resolved to provide the entity identity for a capabilities test.
Service required:
    {nameof(IGetsTargetEntityIdentity<TEntity,TValue>)}<{typeof(TEntity).Name},{typeof(TValue).Name}>

Perhaps it has not be written, or not registered in dependency injection?", ex);
                }
            }

            public EntityIdentityProvider(ILifetimeScope scope)
            {
                this.scope = scope ?? throw new System.ArgumentNullException(nameof(scope));
            }
        }
    }
}
