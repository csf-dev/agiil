using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Agiil.Domain.Capabilities
{
    public class CapabilityEnforcementSpec : ISpecForTypesWhichShouldHaveCapabilitiesEnforced
    {
        public Expression<Func<Type, bool>> GetExpression()
        {
            return t => (t != null
                         && t.IsInterface
                         && t.GetCustomAttribute<EnforceCapabilitiesAttribute>() != null);
        }
    }
}
