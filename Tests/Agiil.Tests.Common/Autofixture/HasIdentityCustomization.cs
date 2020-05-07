using System;
using CSF.Entities;
using AutoFixture;

namespace Agiil.Tests.Autofixture
{
  public static class HasIdentityCustomization
  {
    public static ICustomization Create(Type entityType)
    {
      if(entityType == null)
      {
        throw new ArgumentNullException(nameof(entityType));
      }

      if(!typeof(IEntity).IsAssignableFrom(entityType))
      {
        throw new ArgumentException($"Entity type must implement {typeof(IEntity).Name}.", nameof(entityType));
      }

      var customizationType = typeof(HasIdentityCustomization<>).MakeGenericType(entityType);
      return (ICustomization) Activator.CreateInstance(customizationType);
    }
  }

  public class HasIdentityCustomization<TEntity> : ICustomization where TEntity : IEntity
  {
    public void Customize(IFixture fixture)
    {
      fixture.Customize<TEntity>(x => x.Do(e => e.GenerateIdentity()));
    }
  }
}
