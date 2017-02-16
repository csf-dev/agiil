using System;
using System.Reflection;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace CSF.IssueTracker.Tests.Common
{
  public class EntityIdAttribute : CustomizeAttribute
  {
    Type EntityCustomisationType = typeof(EntityCustomisation<>);

    public override ICustomization GetCustomization (ParameterInfo parameter)
    {
      var entityType = parameter.ParameterType;
      var customisationType = EntityCustomisationType.MakeGenericType(entityType);
      return (ICustomization) Activator.CreateInstance(customisationType);
    }
  }
}
