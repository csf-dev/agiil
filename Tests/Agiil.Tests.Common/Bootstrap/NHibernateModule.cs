using System;
using Agiil.Domain;
using Autofac;
using Autofac.Core.Lifetime;
using NHibernate;

namespace Agiil.Tests.Bootstrap
{
    public class NHibernateModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
              .Register(ctx => ctx.Resolve<ISessionFactory>().OpenSession())
              .InstancePerMatchingLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
        }
    }
}
