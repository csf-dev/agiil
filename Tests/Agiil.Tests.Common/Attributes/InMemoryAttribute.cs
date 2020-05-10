using System;
using System.Reflection;
using Agiil.Tests.Autofixture;
using CSF.ORM;
using AutoFixture;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
  public class InMemoryAttribute : CustomizeAttribute
  {
    public bool GenerateId { get; set; }

    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      if(!typeof(IEntityData).IsAssignableFrom(parameter.ParameterType))
        throw new ArgumentException($"Decorated parameter must implement {nameof(IEntityData)}.");
      
      return new InMemoryEntityDataCustomization(GenerateId);
    }

    public InMemoryAttribute()
    {
      GenerateId = true;
    }
  }
}
