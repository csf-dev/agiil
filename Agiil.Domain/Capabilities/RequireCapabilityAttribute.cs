using System;
namespace Agiil.Domain.Capabilities
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class RequireCapabilityAttribute : Attribute
    {
        public object RequiredCapability { get; }

        public RequireCapabilityAttribute(object requiredCapability)
        {
            this.RequiredCapability = requiredCapability ?? throw new ArgumentNullException(nameof(requiredCapability));
        }
    }
}
