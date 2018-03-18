using System;
using System.Linq;
using Agiil.Domain.Validation;
using Moq;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public class AlwaysPassesValidationCustomization<TValidated> : ICustomization where TValidated : class
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<ICreatesValidators<TValidated>>(c => {
        return c
          .FromFactory(() => Mock.Of<ICreatesValidators<TValidated>>())
          .Do(x => {
            var validator = Mock.Of<CSF.Validation.IValidator>(v => v.Validate(It.IsAny<object>()).IsSuccess == true);
            Mock.Get(x)
              .Setup(f => f.GetValidator())
              .Returns(validator);
          });
      });
    }
  }

  public static class AlwaysPassesValidationCustomization
  {
    static Type GetValidatedType(Type validatorFactoryType)
    {
      if(!typeof(ICreatesValidators).IsAssignableFrom(validatorFactoryType))
        throw new ArgumentException($"The validator factory type must implement {nameof(ICreatesValidators)}.",
                                    nameof(validatorFactoryType));

      var interfacesToConsider = validatorFactoryType
        .GetInterfaces()
        .Union(new [] { validatorFactoryType });

      var genericInterface = (from iface in interfacesToConsider
                              where
                                iface.IsInterface
                                && iface.IsGenericType
                              let genIface = iface.GetGenericTypeDefinition()
                              where genIface == typeof(ICreatesValidators<>)
                              select iface)
        .Single();

      return genericInterface.GenericTypeArguments[0];
    }

    public static ICustomization Create(Type validatorFactoryType)
    {
      if(validatorFactoryType == null)
        throw new ArgumentNullException(nameof(validatorFactoryType));

      var validatedType = GetValidatedType(validatorFactoryType);

      var customizationType = typeof(AlwaysPassesValidationCustomization<>).MakeGenericType(validatedType);
      return (ICustomization) Activator.CreateInstance(customizationType);
    }
  }
}
