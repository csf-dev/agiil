using System;
using System.Reflection;
using NHibernate.Properties;

namespace Agiil.Data.ConventionMappings
{
  public class SourceCollectionAccessor : IPropertyAccessor
  {
    public bool CanAccessThroughReflectionOptimizer => false;

    public IGetter GetGetter(Type theClass, string propertyName)
    {
      var field = GetFieldInfo(theClass, propertyName);
      if(field == null) return null;
      var provider = SourceCollectionGetterSetterFactory.Create(field);
      if(provider == null) return null;
      return provider.GetGetter();
    }

    public ISetter GetSetter(Type theClass, string propertyName)
    {
      var field = GetFieldInfo(theClass, propertyName);
      if(field == null) return null;
      var provider = SourceCollectionGetterSetterFactory.Create(field);
      if(provider == null) return null;
      return provider.GetSetter();
    }

    FieldInfo GetFieldInfo(Type theClass, string propertyName)
    {
      var name = GetFieldName(propertyName);
      return theClass.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
    }

    string GetFieldName(string propertyName)
    {
      var firstCharacter = propertyName.Substring(0, 1);
      return String.Concat(firstCharacter.ToLowerInvariant(), propertyName.Substring(1));
    }
  }
}
