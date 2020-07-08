using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using AutoFixture.NUnit3;
using CSF.Reflection;
using CSF.Specifications;
using System.Linq;
using Moq;

namespace Agiil.Tests.Autofixture
{
    public class HardCodedSpecAttribute : CustomizeAttribute
    {
        readonly bool result;

        public override ICustomization GetCustomization(ParameterInfo parameter)
        {
            return new CreateHardCodedSpecCustomization(parameter, result);
        }

        public HardCodedSpecAttribute(bool result = true)
        {
            this.result = result;
        }
    }

    class CreateHardCodedSpecCustomization : ICustomization
    {
        readonly ParameterInfo param;
        readonly bool result;

        public void Customize(IFixture fixture)
        {
            var spec = new ParameterSpecification(param.ParameterType, param.Name);
            fixture.Customizations.Add(new FilteringSpecimenBuilder(new HardCodedSpecSpecimenBuilder(result), spec));
        }

        public CreateHardCodedSpecCustomization(ParameterInfo param, bool result)
        {
            this.param = param ?? throw new ArgumentNullException(nameof(param));
            this.result = result;
        }
    }

    class HardCodedSpecSpecimenBuilder : ISpecimenBuilder
    {
        static readonly MethodInfo
            OpenGenericCreateSpec = Reflect.Method<HardCodedSpecSpecimenBuilder>(x => x.CreateSpec<ISpecificationExpression<string>, string>())
                                           .GetGenericMethodDefinition();

        readonly bool result;

        public object Create(object request, ISpecimenContext context)
        {
            if(!(request is ParameterInfo param))
                return new NoSpecimen();

            return CreateSpec(param.ParameterType);
        }

        object CreateSpec(Type paramType)
        {
            var specType = (from type in paramType.GetInterfaces()
                            where
                                type.IsGenericType
                                && type.GetGenericTypeDefinition() == typeof(ISpecificationExpression<>)
                            select type)
                 .FirstOrDefault();

            if(specType == null)
                return new NoSpecimen();

            var specifiedType = specType.GetGenericArguments()[0];

            var createSpecMethod = OpenGenericCreateSpec.MakeGenericMethod(paramType, specifiedType);
            return createSpecMethod.Invoke(this, new object[0]);
        }

        TParam CreateSpec<TParam,TSpecifiedType>() where TParam : class, ISpecificationExpression<TSpecifiedType>
        {
            var spec = new Mock<TParam>();
            spec.Setup(x => x.GetExpression()).Returns((TSpecifiedType x) => result);
            return spec.Object;
        }

        public HardCodedSpecSpecimenBuilder(bool result)
        {
            this.result = result;
        }
    }
}
