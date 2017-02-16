using System;
using System.Reflection;
using CSF.Entities;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace CSF.IssueTracker.Tests.Common
{
  public class EntityCustomisation<TEntity> : ICustomization where TEntity : IEntity
  {
    #region constants

    Type
      EntityBaseOpenGenericType = typeof(Entity<>),
      ObjectType = typeof(object);
    string IdentityValuePropertyName = "IdentityValue";

    #endregion

    public void Customize (IFixture fixture)
    {
      fixture.Register<TEntity>(() => {
        Type baseType = typeof(TEntity), identityType;
        while(true)
        {
          if(baseType == ObjectType)
          {
            throw new InvalidOperationException($"The entity type `{typeof(TEntity).Name}' must implement {EntityBaseOpenGenericType.Name}.");
          }

          if(baseType.IsGenericType && baseType.GetGenericTypeDefinition() == EntityBaseOpenGenericType)
          {
            identityType = baseType.GetGenericArguments()[0];
            break;
          }
          else
          {
            baseType = baseType.BaseType;
          }
        }

        var parameterlessCtor = typeof(TEntity).GetConstructor(Type.EmptyTypes);
        if(parameterlessCtor == null)
        {
          throw new InvalidOperationException($"The entity type `{typeof(TEntity).Name}' must have a parameterless constructor.");
        }

        var identityProperty = typeof(TEntity).GetProperty(IdentityValuePropertyName,
                                                      BindingFlags.NonPublic | BindingFlags.Instance);

        var instance = parameterlessCtor.Invoke(Type.EmptyTypes);
        var identity = new SpecimenContext(fixture).Resolve(new SeededRequest(identityType, GetDefaultValue(identityType)));
        identityProperty.SetValue(instance, identity);

        return (TEntity) instance;
      });
    }

    private object GetDefaultValue(Type type)
    {
      return type.IsValueType? Activator.CreateInstance(type) : null;
    }
  }
}
