﻿using System;
using System.Linq;
using System.Reflection;
using CSF.Entities;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace Agiil.Tests.Common
{
  public static class EntityExtensions
  {
    #region fields

    static readonly IFixture fixture;

    #endregion

    #region extension methods

    public static void GenerateIdentity(this IEntity entity)
    {
      if (entity == null) {
        throw new ArgumentNullException (nameof (entity));
      }

      var identityType = entity.GetIdentityType();
      var identity = CreateInstance(identityType);
      entity.SetIdentity(identity);
    }

    #endregion

    #region methods

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
