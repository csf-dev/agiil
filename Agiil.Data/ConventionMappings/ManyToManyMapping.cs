using System;
using System.Reflection;
using Agiil.Domain;
using NHibernate.Mapping.ByCode;
using Agiil.Data.MappingProviders;

namespace Agiil.Data.ConventionMappings
{
  public class ManyToManyMapping : IConventionMapping
  {
    readonly IDbNameFormatter formatter;

    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsManyToMany((member, declared) => {
        var property = member as PropertyInfo;

        if(property == null || !property.CanRead || !property.CanWrite)
          return false;

        if(property.GetCustomAttribute<ManyToManyAttribute>() != null)
          return true;

        return false;
      });

      mapper.BeforeMapSet += (modelInspector, propertyPath, propertyCustomizer) => {
        var manyToManyAttrib = propertyPath.LocalMember.GetCustomAttribute<ManyToManyAttribute>();

        if(manyToManyAttrib == null) return;

        propertyCustomizer.Inverse(!manyToManyAttrib.IsActiveSide);

        var activeEntityType = GetActiveType(propertyPath.LocalMember, manyToManyAttrib.IsActiveSide);
        var inactiveEntityType = GetInactiveType(propertyPath.LocalMember, manyToManyAttrib.IsActiveSide);

        propertyCustomizer.Table(formatter.GetManyToManyTableName(activeEntityType, inactiveEntityType));

        propertyCustomizer.Key(keyMap => {
          var parentType = GetDeclaringType(propertyPath.LocalMember);
          var childType = GetCollectionType(propertyPath.LocalMember);

          var columnName = formatter.GetIdentityColumnName(parentType);
          var fkName = formatter.GetForeignKeyConstraintName(activeEntityType, inactiveEntityType);

          keyMap.Column(columnName);
          keyMap.ForeignKey(fkName);
        });
      };

      mapper.BeforeMapManyToMany += (modelInspector, propertyPath, collectionRelationManyToManyCustomizer) => {
        var myType = GetDeclaringType(propertyPath.LocalMember);
        var oppositeType = GetCollectionType(propertyPath.LocalMember);

        collectionRelationManyToManyCustomizer.Column(formatter.GetIdentityColumnName(oppositeType));
        collectionRelationManyToManyCustomizer.ForeignKey(formatter.GetForeignKeyConstraintName(oppositeType, myType));
      };

      /*
      mapper.BeforeMapMapKeyManyToMany += (modelInspector, member, mapKeyManyToManyCustomizer) => {
        
      };
      */
    }

    Type GetActiveType(MemberInfo member, bool isActiveSide)
    {
      return isActiveSide? GetDeclaringType(member) : GetCollectionType(member);
    }

    Type GetInactiveType(MemberInfo member, bool isActiveSide)
    {
      return isActiveSide? GetCollectionType(member) : GetDeclaringType(member);
    }

    Type GetDeclaringType(MemberInfo member) => member.DeclaringType;

    Type GetCollectionType(MemberInfo member)
    {
      
      var collectionType = (member as PropertyInfo)?.PropertyType;
      if(collectionType == null || !collectionType.IsGenericType) return null;
      return collectionType.GetGenericArguments()[0];
    }

    public ManyToManyMapping(IDbNameFormatter formatter)
    {
      if(formatter == null)
        throw new ArgumentNullException(nameof(formatter));

      this.formatter = formatter;
    }
  }
}
