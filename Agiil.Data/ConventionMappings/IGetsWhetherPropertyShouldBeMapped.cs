using System;
using System.Reflection;

namespace Agiil.Data.ConventionMappings
{
    public interface IGetsWhetherPropertyShouldBeMapped
    {
        bool ShouldMapProperty(PropertyInfo property);
    }
}
