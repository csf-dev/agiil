using System;
using System.Reflection;
using Agiil.Tests.Autofixture;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests
{
  public class HasIdentityAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      return HasIdentityCustomization.Create(parameter.ParameterType);
    }
  }
}
