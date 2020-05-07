using System;
using AutoFixture;
using AutoFixture.Kernel;

namespace Agiil.Tests.Autofixture
{
    public class FromDiCustomization : ICustomization
    {
        readonly Type objectType, lazyType;
        readonly string parameterName;

        public void Customize(IFixture fixture)
        {
            var spec = new ParameterSpecification(objectType, parameterName);
            fixture.Customizations.Add(new FilteringSpecimenBuilder(new FromDiSpecimenBuilder(lazyType), spec));
        }

        Type GetLazyType(Type possibleLazyType)
        {
            if(!possibleLazyType.IsGenericType || possibleLazyType.GetGenericTypeDefinition() != typeof(Lazy<>))
                throw new ArgumentException("The type must be a Lazy<T>", nameof(possibleLazyType));

            return possibleLazyType.GenericTypeArguments[0];
        }

        public FromDiCustomization(Type objectType, string parameterName)
        {
            this.objectType = objectType ?? throw new ArgumentNullException(nameof(objectType));
            this.parameterName = parameterName ?? throw new ArgumentNullException(nameof(parameterName));
            lazyType = GetLazyType(objectType);
        }
    }
}
