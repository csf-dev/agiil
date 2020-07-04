using Agiil.Domain.Capabilities;
using Autofac;
using CSF.Entities;

namespace Agiil.Bootstrap.Capabilities
{
    public class TargetEntityIdentityProvidersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EntityIdentityProviderFactory>()
                .AsSelf()
                .AsImplementedInterfaces();
        }

        public class EntityIdentityProviderFactory : IGetsTargetEntityIdentityProvider
        {
            readonly ILifetimeScope scope;

            public IGetsTargetEntityIdentity<TEntity, TObject> GetIdentityProvider<TEntity, TObject>() where TEntity : IEntity
            {
                if(typeof(IIdentity<TEntity>).IsAssignableFrom(typeof(TObject)))
                    return (IGetsTargetEntityIdentity<TEntity, TObject>) new EntityIdentityProviderAdapter<TEntity>();

                try
                {
                    return scope.Resolve<IGetsTargetEntityIdentity<TEntity, TObject>>();
                }
                catch(Autofac.Core.Registration.ComponentNotRegisteredException ex)
                {
                    throw new IdentityProviderNotAvailableException($@"No service could be resolved to provide the entity identity for a capabilities test.
Service required:
    {nameof(IGetsTargetEntityIdentity<TEntity, TObject>)}<{typeof(TEntity).Name},{typeof(TObject).Name}>

Perhaps it has not be written, or not registered in dependency injection?", ex);
                }
            }

            public EntityIdentityProviderFactory(ILifetimeScope scope)
            {
                this.scope = scope ?? throw new System.ArgumentNullException(nameof(scope));
            }
        }
    }
}
