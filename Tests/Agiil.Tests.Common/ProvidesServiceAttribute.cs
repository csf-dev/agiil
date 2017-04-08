using System;
using System.Reflection;
using Agiil.Tests.Common.Customizations;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Common
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
