using System;
using NHibernate.Properties;

namespace Agiil.Data.ConventionMappings
{
  public class SourceCollectionAccessor : IPropertyAccessor
  {
    internal const string PropertyNamePrefix = "Source";

    readonly BasicPropertyAccessor accessor;

    public bool CanAccessThroughReflectionOptimizer => accessor.CanAccessThroughReflectionOptimizer;

    public IGetter GetGetter(Type theClass, string propertyName)
    {
      if(propertyName == null)
        throw new ArgumentNullException(nameof(propertyName));
      if(theClass == null)
        throw new ArgumentNullException(nameof(theClass));
      
      return accessor.GetGetter(theClass, String.Concat(PropertyNamePrefix, propertyName));
    }

    public ISetter GetSetter(Type theClass, string propertyName)
    {
      if(propertyName == null)
        throw new ArgumentNullException(nameof(propertyName));
      if(theClass == null)
        throw new ArgumentNullException(nameof(theClass));

      return accessor.GetSetter(theClass, String.Concat(PropertyNamePrefix, propertyName));
    }

    public SourceCollectionAccessor()
    {
      accessor = new BasicPropertyAccessor();
    }
  }
}
