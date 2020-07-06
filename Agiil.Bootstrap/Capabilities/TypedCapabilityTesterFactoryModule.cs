using System;
using Agiil.Domain.Capabilities;
using Autofac;
using CSF.Entities;

namespace Agiil.Bootstrap.Capabilities
{
    public class TypedCapabilityTesterFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TypedCapabilityTesterFactory>().AsSelf().AsImplementedInterfaces();
        }

        public class TypedCapabilityTesterFactory : IGetsTypedCapabilityTester
        {
            readonly ILifetimeScope scope;

            public IAssertsUserHasCapability<TEntity, TCapability> GetCapabilityTester<TEntity, TCapability>()
                where TEntity : IEntity
                where TCapability : struct,Enum
            {
                return scope.Resolve<IAssertsUserHasCapability<TEntity, TCapability>>();
            }

            public TypedCapabilityTesterFactory(ILifetimeScope scope)
            {
                this.scope = scope ?? throw new ArgumentNullException(nameof(scope));
            }
        }
    }
}
