using System;
using Agiil.Domain;
using Agiil.Tests.Attributes;
using Autofac;
using Autofac.Core.Lifetime;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Agiil.Tests.Attributes
{
    public class WithDiCommand : DelegatingTestCommand
    {
        readonly IContainer diContainer;

        public override TestResult Execute(TestExecutionContext context)
        {
            ILifetimeScope scope = null;

            try
            {
                scope = diContainer.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
                context.CurrentTest.Properties.Add(WithDiAttribute.LifetimeScopeKey, scope);
                context.CurrentResult = innerCommand.Execute(context);
            }
            finally
            {
                scope?.Dispose();
            }

            return context.CurrentResult;
        }

        public WithDiCommand(TestCommand innerCommand, IContainer diContainer) : base(innerCommand)
        {
            this.diContainer = diContainer ?? throw new ArgumentNullException(nameof(diContainer));
        }
    }
}
