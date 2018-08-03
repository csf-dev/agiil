using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using CSF.Reflection;

namespace Agiil.Data.MappingProviders
{
  public class LowercaseWithUnderscoreDbNameFormatter : IDbNameFormatter
  {
    const string
      FirstUppercaseLetterPattern = @"^[A-Z]",
      OtherUppercaseLetterPattern = @"([a-z0-9])([A-Z])",
      Underscore = "_",
      IdentitySuffix = "Id",
      ConstraintPrefix = "Fk",
      ConstraintJoiner = "Has",
      IndexPrefix = "Idx",
      UniqueJoiner = "Unique",
      ManyToManyJoiner = "To";

    static readonly Regex
      FirstUppercaseLetterMatcher = new Regex(FirstUppercaseLetterPattern, RegexOptions.Compiled),
      OtherUppercaseLetterMatcher = new Regex(OtherUppercaseLetterPattern, RegexOptions.Compiled);

    public string GetTableName(Type entityType)
    {
      return GetDatabaseName(entityType?.Name);
    }

    public string GetManyToManyTableName(Type primaryEntityType, Type secondaryEntityType)
    {
      return GetDatabaseName(String.Concat(primaryEntityType?.Name, ManyToManyJoiner, secondaryEntityType?.Name));
    }

    public string GetIdentityColumnName(Type entityType)
    {
      return GetDatabaseName(String.Concat(entityType?.Name, IdentitySuffix));
    }

    public string GetColumnName(MemberInfo member)
    {
      return GetDatabaseName(member?.Name);
    }

    public string GetForeignKeyColumnName(MemberInfo member)
    {
      return GetDatabaseName(String.Concat(member?.Name, "Id"));
    }

    public string GetIndexName(Type entityType, MemberInfo member)
    {
      return GetDatabaseName(String.Concat(IndexPrefix, entityType?.Name, member?.Name));
    }

    public string GetIndexName(Type entityType, Type referencedType)
    {
      return GetDatabaseName(String.Concat(IndexPrefix, entityType?.Name, referencedType?.Name, IdentitySuffix));
    }

    public string GetUniqueIndexName(Type entityType, MemberInfo member)
    {
      return GetDatabaseName(String.Concat(IndexPrefix, UniqueJoiner, entityType?.Name, member?.Name));
    }

    public string GetUniqueIndexName<TEntity>(Expression<Func<TEntity,object>> memberExpression)
      => GetUniqueIndexName(typeof(TEntity), Reflect.Member(memberExpression));

    public string GetForeignKeyConstraintName(Type parent, Type child)
    {
      return GetDatabaseName(String.Concat(ConstraintPrefix, child?.Name, ConstraintJoiner, parent?.Name));
    }

    public string GetForeignKeyConstraintName(MemberInfo parentMember, Type child)
    {
      return GetDatabaseName(String.Concat(ConstraintPrefix, child?.Name, ConstraintJoiner, parentMember?.Name));
    }

    string GetDatabaseName(string clrName)
    {
      if(ReferenceEquals(clrName, null))
        return null;

      var output = FirstUppercaseLetterMatcher.Replace(clrName, m => {
        return m.Groups[0].Value.ToLowerInvariant();
      });
      output = OtherUppercaseLetterMatcher.Replace(output, m => {
        return String.Concat(m.Groups[1].Value, Underscore, m.Groups[2].Value.ToLowerInvariant());
      });

      return output;
    }
  }
}
