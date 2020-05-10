using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.NUnit3;
using log4net;

namespace Agiil.Tests.Attributes
{
    public class LoggerForAttribute : CustomizeAttribute
    {
        readonly Type type;

        public override ICustomization GetCustomization(ParameterInfo parameter)
            => new LoggerForCustomization(type);

        public LoggerForAttribute(Type type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
        }

        class LoggerForCustomization : ICustomization
        {
            readonly Type type;

            public void Customize(IFixture fixture)
                => fixture.Customize<ILog>(c => c.FromFactory(() => LogManager.GetLogger(type)));

            public LoggerForCustomization(Type type)
            {
                this.type = type ?? throw new ArgumentNullException(nameof(type));
            }
        }
    }
}
