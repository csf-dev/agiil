using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Agiil.Data.MappingProviders
{
  public interface IDbNameFormatter
  {
    string GetTableName(Type entityType);

    string GetManyToManyTableName(Type primaryEntityType, Type secondaryEntityType);

    string GetIdentityColumnName(Type entityType);

    string GetColumnName(MemberInfo member);

    string GetForeignKeyColumnName(MemberInfo member);

    string GetIndexName(Type entityType, MemberInfo member);

    string GetIndexName(Type entityType, Type referencedType);

    string GetUniqueIndexName(Type entityType, MemberInfo member);

    string GetUniqueIndexName<TEntity>(Expression<Func<TEntity,object>> memberExpression);

    string GetForeignKeyConstraintName(Type parent, Type child);

    string GetForeignKeyConstraintName(MemberInfo parentMember, Type child);
  }
}
