using System;
using System.Reflection;
using Agiil.Tests.Autofixture;
using AutoFixture;
using AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
    public class FromDiAttribute : CustomizeAttribute
    {
        public override ICustomization GetCustomization(ParameterInfo parameter)
            => new FromDiCustomization(parameter.ParameterType, parameter.Name);
    }
}
