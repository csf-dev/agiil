using System;
using System.Reflection;
using Agiil.Tests.Autofixture;
using AutoFixture;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
  public class ProvidesServiceAttribute : CustomizeAttribute
  {
    readonly Type abstractType;

    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      return new TypeRelayCustomization(abstractType, parameter.ParameterType);
    }

    public ProvidesServiceAttribute(Type abstractType)
    {
      if(abstractType == null)
        throw new ArgumentNullException(nameof(abstractType));

      this.abstractType = abstractType;
    }
  }
}
