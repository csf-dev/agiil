using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Agiil.Domain.Capabilities
{
    public class CapabilityAssertionSpecProvider : IGetsCapabilitiesAssertionsToPerform
    {
        public IReadOnlyCollection<CapabilitiesAssertionSpec> GetAssertionsToPerform(MethodInfo method, object[] parameterValues)
        {
            var paramsAndValues = GetParametersAndValues(method, parameterValues);

            return (from paramAndValue in paramsAndValues
                    let attrib = paramAndValue.Item1.GetCustomAttribute<RequireCapabilityAttribute>()
                    where attrib != null
                    select new CapabilitiesAssertionSpec(paramAndValue.Item1.Name,
                                                         paramAndValue.Item1.ParameterType,
                                                         paramAndValue.Item2,
                                                         attrib,
                                                         GetActionName(method)))
                .ToList();
        }

        static string GetActionName(MethodInfo method) => $"{method.DeclaringType.Name}.{method.Name}";

        static IEnumerable<(ParameterInfo,object)> GetParametersAndValues(MethodInfo method, object[] parameterValues)
        {
            if(method == null)
                throw new ArgumentNullException(nameof(method));
            if(parameterValues == null)
                throw new ArgumentNullException(nameof(parameterValues));

            var parameters = method.GetParameters();
            if(parameters.Length != parameterValues.Length)
                throw new ArgumentException($"The {nameof(parameterValues)} must contain the same number of items as the count of parameters in the specified {nameof(method)}.",
                                            nameof(parameterValues));

            for(var i = 0; i < parameters.Length; i++)
                yield return ( parameters[i], parameterValues[i] );
        }
    }
}
