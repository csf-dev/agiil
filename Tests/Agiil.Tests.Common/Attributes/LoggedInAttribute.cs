using System;
using System.Reflection;
using Agiil.Domain.Auth;
using Agiil.Tests.Autofixture;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
  public class LoggedInAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      if(parameter.ParameterType != typeof(User))
      {
        throw new InvalidOperationException($"`{nameof(LoggedInAttribute)}' is only valid for `{nameof(User)}' parameters.");
      }

      return new LoggedInCustomization();
    }
  }
}
