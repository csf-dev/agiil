using System;
using System.Reflection;
using CSF.Reflection;
using CSF.Specifications;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;
using System.Linq;

namespace Agiil.Tests.Attributes
{
    public class TrueSpecExprAttribute : CustomizeAttribute
    {
        static readonly ISpecificationExpression<Type> IsSpec = new DerivesFromOpenGenericSpecification(typeof(ISpecificationExpression<>));

        public override ICustomization GetCustomization(ParameterInfo parameter)
        {
            if(!IsSpec.Matches(parameter.ParameterType))
                throw new ArgumentException($"The parameter must derive from ISpecificationExpression<T>",
                                            nameof(parameter));

            var customizationType = typeof(TrueSpecExprCustomization<>).MakeGenericType(parameter.ParameterType);
            return (ICustomization) Activator.CreateInstance(customizationType);
        }
    }

    public class TrueSpecExprCustomization<TObj> : ICustomization where TObj : class
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Mock<TObj>>(c => {
                return c
                    .FromFactory(() => new Mock<TObj>())
                    .Do(obj => {
                        var specInterfaces = (from type in typeof(TObj).GetInterfaces()
                                              where type.IsGenericType
                                              let genType = type.GetGenericTypeDefinition()
                                              where genType == typeof(ISpecificationExpression<>)
                                              select type.GenericTypeArguments[0])
                            .ToList();

                        // For every ISpecificationExpression<TSpec> interface TObj implements, configure the mock to return true for it.
                        foreach(var iface in specInterfaces)
                        {
                            var method = GetType().GetMethod(nameof(CustomizeSpec), BindingFlags.Static | BindingFlags.NonPublic);
                            var genMethod = method.MakeGenericMethod(iface);
                            genMethod.Invoke(null, new[] { obj });
                        }
                    });
            });

            fixture.Customize<TObj>(c => c.FromFactory((Mock<TObj> mock) => mock.Object));
        }

        static void CustomizeSpec<TSpec>(Mock<TObj> mock)
        {
            mock
                .As<ISpecificationExpression<TSpec>>()
                .Setup(x => x.GetExpression())
                .Returns(x => true);
        }
    }
}
