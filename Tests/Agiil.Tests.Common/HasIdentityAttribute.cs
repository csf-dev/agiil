using System;
using System.Reflection;
using Agiil.Tests.Common.Customizations;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Common
{
  public class HasIdentityAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      return HasIdentityCustomization.Create(parameter.ParameterType);
    }
  }
}
