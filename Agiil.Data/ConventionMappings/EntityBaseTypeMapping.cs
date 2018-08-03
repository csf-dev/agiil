using System;
using CSF.Entities;
using NHibernate.Mapping.ByCode;
using Agiil.Data.MappingProviders;

namespace Agiil.Data.ConventionMappings
{
  public class EntityBaseTypeMapping : IConventionMapping
  {
    public void ApplyMapping(ConventionModelMapper mapper)
    {
      mapper.IsRootEntity(IsRootEntity);
    }

    /// <summary>
    /// Watch out - there is a lot of documentation on the Internet which says that the "root entity" should be
    /// an unmapped base type for entities (layer subtype).  This is incorrect, this is supposed to be true
    /// for a mapped entity which is the at the root of an entity hierarchy mapping.  In other words, this should be
    /// true for all entities which are not subclasses of other entities.
    /// </summary>
    /// <returns><c>true</c>, if the type is a root entity, <c>false</c> otherwise.</returns>
    /// <param name="type">A type to consider.</param>
    /// <param name="isDeclaredAsRootAlready">If set to <c>true</c> then the entity has been declared as a root entity already.</param>
    bool IsRootEntity(Type type, bool isDeclaredAsRootAlready)
    {
      if(type.IsInterface) return false;
      if(type == typeof(object)) return false;
      return AgiilMappingProvider.IsEntityBaseType(type.BaseType);
    }
  }
}
