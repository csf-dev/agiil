using System;
using System.Reflection;
using Agiil.Tests.Autofixture;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
  [AttributeUsage(AttributeTargets.Parameter)]
  public class AlwaysPassesAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      return AlwaysPassesValidationCustomization.Create(parameter.ParameterType);
    }
  }
}
