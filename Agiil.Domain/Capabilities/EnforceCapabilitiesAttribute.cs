using System;
namespace Agiil.Domain.Capabilities
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class EnforceCapabilitiesAttribute : Attribute { }
}
