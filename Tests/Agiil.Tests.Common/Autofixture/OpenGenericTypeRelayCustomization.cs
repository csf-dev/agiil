using System;
using AutoFixture;
using AutoFixture.Kernel;

namespace Agiil.Tests.Autofixture
{
    public class OpenGenericTypeRelayCustomization : ICustomization
    {
        readonly Type serviceType, implType;

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new OpenGenericTypeRelaySpecimenBuilder(serviceType, implType));
        }

        public OpenGenericTypeRelayCustomization(Type serviceType, Type implType)
        {
            this.serviceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
            this.implType = implType ?? throw new ArgumentNullException(nameof(implType));
        }

        class OpenGenericTypeRelaySpecimenBuilder : ISpecimenBuilder
        {
            readonly Type serviceType, implType;

            public object Create(object request, ISpecimenContext context)
            {
                var typeRequest = request as Type;
                if(typeRequest == null) return new NoSpecimen();

                if(!typeRequest.IsGenericType
                    || typeRequest.GetGenericTypeDefinition() != serviceType)
                    return new NoSpecimen();

                var genericParams = typeRequest.GetGenericArguments();
                var closedImplType = implType.MakeGenericType(genericParams);
                return context.Resolve(closedImplType);
            }

            public OpenGenericTypeRelaySpecimenBuilder(Type serviceType, Type implType)
            {
                this.serviceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
                this.implType = implType ?? throw new ArgumentNullException(nameof(implType));

                if(!this.serviceType.IsGenericTypeDefinition)
                    throw new ArgumentException("The service (source) type must be an open generic type definition.", nameof(serviceType));
                if(!this.implType.IsGenericTypeDefinition)
                    throw new ArgumentException("The implementation (destination) type must be an open generic type definition.", nameof(implType));
                if(this.serviceType.GetGenericArguments().Length != this.implType.GetGenericArguments().Length)
                    throw new ArgumentException("The implementation (destination) type must have the same number of generic type arguments as the service (source) type.");

            }
        }
    }
}
