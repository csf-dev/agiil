using System;
using System.Reflection;
using Agiil.Tests.Attributes;
using Autofac;
using NUnit.Framework;
using Ploeh.AutoFixture.Kernel;

namespace Agiil.Tests.Autofixture
{
    public class FromDiSpecimenBuilder : ISpecimenBuilder
    {
        readonly Type paramType;

        public object Create(object request, ISpecimenContext context)
        {
            if(request is ParameterInfo param)
            {
                var member = GetType().GetMethod(nameof(GetLazyValue), BindingFlags.Instance | BindingFlags.NonPublic);
                return member.MakeGenericMethod(paramType).Invoke(this, new object[0]);
            }

            return new NoSpecimen();
        }

        Lazy<T> GetLazyValue<T>() => new Lazy<T>(GetValue<T>);

        T GetValue<T>()
        {
            var props = TestContext.CurrentContext.Test.Properties;
            var scope = props.Get(WithDiAttribute.LifetimeScopeKey) as ILifetimeScope;
            return scope.Resolve<T>();
        }

        public FromDiSpecimenBuilder(Type paramType)
        {
            this.paramType = paramType ?? throw new ArgumentNullException(nameof(paramType));
        }
    }
}
