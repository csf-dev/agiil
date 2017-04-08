using System;
using System.Reflection;
using Agiil.Domain.Auth;
using Agiil.Tests.Common.Customizations;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Common
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
