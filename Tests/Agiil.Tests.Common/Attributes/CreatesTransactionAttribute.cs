using System;
using System.Reflection;
using Agiil.Tests.Autofixture;
using AutoFixture;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
  [AttributeUsage(AttributeTargets.Parameter)]
  public class CreatesTransactionAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      return new CreatesTransactionCustomization();
    }
  }
}
