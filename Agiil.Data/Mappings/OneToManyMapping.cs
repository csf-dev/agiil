﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Domain;
using CSF.Entities;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.Mappings
{
  public class OneToManyMapping : IMapping
  {
    readonly IDbNameFormatter formatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsOneToMany((member, isDeclared) => {
        if(isDeclared)
          return true;

        if(member.GetCustomAttribute<ManyToManyAttribute>() != null)
          return false;

        var isSourceCollection = member.Name.StartsWith(SourceCollectionAccessor.PropertyNamePrefix,
                                                        StringComparison.InvariantCulture);

        return !isSourceCollection;
      });

      mapper.IsSet((member, isDeclared) => {
        if(isDeclared)
          return true;

        var prop = member as PropertyInfo;

        if(prop == null || !prop.CanRead)
          return false;

        var propertyType = prop.PropertyType;

        if(!propertyType.IsGenericType || propertyType.GetGenericTypeDefinition() != typeof(ISet<>))
          return false;

        if(!typeof(IEntity).IsAssignableFrom(propertyType.GetGenericArguments()[0]))
          return false;

        var isSourceCollection = member.Name.StartsWith(SourceCollectionAccessor.PropertyNamePrefix,
                                                        StringComparison.InvariantCulture);
        if(isSourceCollection)
          return false;
        
        return true;
      });

      mapper.BeforeMapSet += (modelInspector, propertyPath, propertyCustomizer) => {
        propertyCustomizer.Cascade(Cascade.All | Cascade.DeleteOrphans);

        propertyCustomizer.Access(typeof(SourceCollectionAccessor));

        if(propertyPath.LocalMember.GetCustomAttribute<ManyToManyAttribute>() != null)
          return;

        propertyCustomizer.Key(keyMap => {
          var parentType = propertyPath.LocalMember.DeclaringType;
          var childType = propertyPath.LocalMember.GetPropertyOrFieldType().GetGenericArguments()[0];

          var columnName = formatter.GetIdentityColumnName(parentType);
          var fkName = formatter.GetForeignKeyConstraintName(parentType, childType);

          keyMap.Column(columnName);
          keyMap.ForeignKey(fkName);
        });

        propertyCustomizer.Inverse(true);
      };
    }

    public OneToManyMapping(IDbNameFormatter formatter)
    {
      if(formatter == null)
        throw new ArgumentNullException(nameof(formatter));
      this.formatter = formatter;
    }
  }
}