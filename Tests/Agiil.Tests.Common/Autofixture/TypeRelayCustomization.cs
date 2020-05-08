using System;
using AutoFixture;
using AutoFixture.Kernel;

namespace Agiil.Tests.Autofixture
{
  public class TypeRelayCustomization : ICustomization
  {
    readonly Type abstractType, concreteType;

    public void Customize(IFixture fixture)
    {
      fixture.Customizations.Add(new TypeRelay(abstractType, concreteType));
    }

    public TypeRelayCustomization(Type abstractType, Type concreteType)
    {
      if(concreteType == null)
        throw new ArgumentNullException(nameof(concreteType));
      if(abstractType == null)
        throw new ArgumentNullException(nameof(abstractType));

      this.abstractType = abstractType;
      this.concreteType = concreteType;
    }
  }
}
