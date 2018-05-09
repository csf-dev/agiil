using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Domain;
using CSF.Entities;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.MappingProviders
{
  public class AgiilMappingProvider : IGetsHbmMapping
  {
    const string MappingName = "AgiilMappingsByCode";

    internal static readonly Type BaseEntityType = typeof(IEntity);

    readonly IEnumerable<Func<IConventionMapping>> allMappings;

    public string Name => MappingName;

    public HbmMapping GetHbmMapping()
    {
      var mapper = new ConventionModelMapper();

      var mappings = GetMappings();

      foreach(var mapping in mappings)
      {
        mapping.ApplyMapping(mapper);
      }

      var entityTypes = GetAutomappedEntityTypes();

      return mapper.CompileMappingFor(entityTypes);
    }

    IEnumerable<IConventionMapping> GetMappings()
    {
      return allMappings.Select(x => x()).ToArray();
    }

    Type[] GetAutomappedEntityTypes()
    {
      var domainAssembly = typeof(IDomainAssemblyMarker).Assembly;

      return (from type in domainAssembly.GetExportedTypes()
              where
                BaseEntityType.IsAssignableFrom(type)
                && type.IsClass
              select type)
        .ToArray();
    }

    public AgiilMappingProvider(IEnumerable<Func<IConventionMapping>> allMappings)
    {
      if(allMappings == null)
        throw new ArgumentNullException(nameof(allMappings));

      this.allMappings = allMappings;
    }
  }
}
