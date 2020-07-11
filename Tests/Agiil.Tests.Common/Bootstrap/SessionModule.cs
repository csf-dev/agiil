using System;
using System.Collections.Generic;
using Agiil.Domain;
using Autofac;
using Autofac.Core.Lifetime;
using Moq;

namespace Agiil.Tests.Bootstrap
{
    public class SessionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<InMemorySession>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerMatchingLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
        }

        class InMemorySession : IAppSessionStore
        {
            readonly Dictionary<string, object> data = new Dictionary<string, object>();

            public void Set<T>(string key, T value)
            {
                data[key] = value;
            }

            public bool TryGet<T>(string key, out T value)
            {
                value = default(T);
                if(!data.ContainsKey(key)) return false;
                try
                {
                    value = (T) data[key];
                    return true;
                }
                catch(InvalidCastException)
                {
                    return false;
                }
            }
        }

    }
}
