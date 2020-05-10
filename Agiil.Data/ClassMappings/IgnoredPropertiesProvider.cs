using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Data.ConventionMappings;
using Agiil.Domain.Tickets;
using CSF.Reflection;

namespace Agiil.Data.ClassMappings
{
    public class IgnoredPropertiesProvider : IGetsWhetherPropertyShouldBeMapped
    {
        public bool ShouldMapProperty(PropertyInfo property)
        {
            var ignoredProperties = GetIgnoredProperties();
            return !ignoredProperties.Contains(property);
        }

        IReadOnlyList<PropertyInfo> GetIgnoredProperties()
        {
            return new[] {
                Reflect.Property<Relationship>(x => x.Type)
            };
        }
    }
}
