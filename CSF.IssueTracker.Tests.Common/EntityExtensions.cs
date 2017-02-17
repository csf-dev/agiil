using System;
using System.Linq;
using System.Reflection;
using CSF.Entities;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace CSF.IssueTracker.Tests.Common
{
  public static class EntityExtensions
  {
    #region constants

    static readonly Type EntityOpenGenericType = typeof(Entity<>), ObjectType = typeof(object);
    static readonly string IdentityPropertyName = "IdentityValue";

    #endregion

    #region fields

    static readonly IFixture fixture;

    #endregion

    #region extension methods

    public static void SetIdentity<TIdentity>(this IEntity entity, TIdentity identity)
    {
      if (entity == null) {
        throw new ArgumentNullException (nameof (entity));
      }

      SetIdentity(entity.GetType(), entity, identity);
    }

    public static void SetIdentity(this IEntity entity)
    {
      if (entity == null) {
        throw new ArgumentNullException (nameof (entity));
      }

      var identityType = GetIdentityType(entity.GetType());
      var identity = CreateInstance(identityType);
      SetIdentity(entity.GetType(), entity, identity);
    }

    #endregion

    #region methods

    static void SetIdentity(Type entityType, object instance, object identityValue)
    {
      var property = entityType.GetProperty(IdentityPropertyName, BindingFlags.NonPublic | BindingFlags.Instance);
      property.SetValue(instance, identityValue);
    }

    static Type GetIdentityType(Type entityType)
    {
      var baseType = entityType;
      while(true)
      {
        if(baseType == ObjectType)
        {
          throw new ArgumentException($"Type `{entityType.Name}' must implement `{EntityOpenGenericType.Name}'.");
        }

        if(baseType.IsGenericType && baseType.GetGenericTypeDefinition() == EntityOpenGenericType)
        {
          return baseType.GenericTypeArguments.First();
        }

        baseType = baseType.BaseType;
      }
    }

    static object CreateInstance(Type type)
    {
      return new SpecimenContext(fixture).Resolve(new SeededRequest(type, GetDefaultValue(type)));
    }

    static object GetDefaultValue(Type type)
    {
      return type.IsValueType? Activator.CreateInstance(type) : null;
    }

    #endregion

    #region constructor

    static EntityExtensions ()
    {
      fixture = new Fixture();
    }

    #endregion
  }
}
