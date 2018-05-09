using System;
using System.Reflection;

namespace Agiil.Data
{
  public interface IDbNameFormatter
  {
    string GetTableName(Type entityType);

    string GetManyToManyTableName(Type primaryEntityType, Type secondaryEntityType);

    string GetIdentityColumnName(Type entityType);

    string GetColumnName(MemberInfo member);

    string GetIndexName(Type entityType, MemberInfo member);

    string GetIndexName(Type entityType, Type referencedType);

    string GetForeignKeyConstraintName(Type parent, Type child);
  }
}
