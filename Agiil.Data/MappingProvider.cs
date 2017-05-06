﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Domain;
using CSF.Entities;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data
{
  public class MappingProvider : IMappingProvider
  {
    internal static readonly Type BaseEntityType = typeof(IEntity);

    readonly IEnumerable<Func<IMapping>> allMappings;

    public HbmMapping GetHbmMapping()
    {
      var mapper = new ConventionModelMapper();

      var mappings = GetMappings();

      foreach(var mapping in mappings)
      {
        mapping.ApplyMapping(mapper);
      }

      var entityTypes = GetEntityTypes();

      return mapper.CompileMappingFor(entityTypes);
    }

    IEnumerable<IMapping> GetMappings()
    {
      return allMappings.Select(x => x()).ToArray();
    }

    Type[] GetEntityTypes()
    {
      var domainAssembly = typeof(IDomainAssemblyMarker).Assembly;

      return (from type in domainAssembly.GetExportedTypes()
              where
              BaseEntityType.IsAssignableFrom(type)
              && type.IsClass
              select type)
        .ToArray();
    }

    public MappingProvider(IEnumerable<Func<IMapping>> allMappings)
    {
      if(allMappings == null)
        throw new ArgumentNullException(nameof(allMappings));

      this.allMappings = allMappings;
    }
  }
}
