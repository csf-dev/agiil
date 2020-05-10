using System;
using System.Collections.Concurrent;
using Agiil.Bootstrap;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Commands;

namespace Agiil.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class WithDiAttribute : PropertyAttribute, IWrapSetUpTearDown
    {
        internal const string LifetimeScopeKey = "DI lifetime scope";

        static readonly ConcurrentDictionary<Type, IGetsAutofacContainer> cachedContainers = new ConcurrentDictionary<Type, IGetsAutofacContainer>();
        readonly Type containerProviderType;

        public ActionTargets Targets => ActionTargets.Test;

        public TestCommand Wrap(TestCommand command)
        {
            var provider = cachedContainers.GetOrAdd(containerProviderType, t => (IGetsAutofacContainer) Activator.CreateInstance(t));
            var container = provider.GetContainer();
            return new WithDiCommand(command, container);
        }

        public WithDiAttribute(Type containerProviderType = null)
        {
            this.containerProviderType = containerProviderType ?? typeof(CachingDomainContainerFactory);
        }
    }
}
