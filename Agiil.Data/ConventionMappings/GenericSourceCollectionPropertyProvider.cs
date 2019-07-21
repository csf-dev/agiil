using System;
using System.Linq;
using System.Reflection;
using CSF.Collections.EventRaising;
using NHibernate.Properties;

namespace Agiil.Data.ConventionMappings
{
  public class GenericSourceCollectionPropertyProvider<TCollectionItem> : GenericSourceCollectionPropertyProvider
    where TCollectionItem : class
  {
    readonly FieldInfo field;

    public override IGetter GetGetter()
      => new SourceCollectionGetterSetter<TCollectionItem>(field);

    public override ISetter GetSetter()
      => new SourceCollectionGetterSetter<TCollectionItem>(field);

    public GenericSourceCollectionPropertyProvider(FieldInfo field)
    {
      this.field = field ?? throw new ArgumentNullException(nameof(field));
    }
  }

  public abstract class GenericSourceCollectionPropertyProvider
  {
    static readonly Type EventRaisingCollectionType = typeof(IEventRaisingCollectionWrapper<>);

    public abstract IGetter GetGetter();

    public abstract ISetter GetSetter();

    public static GenericSourceCollectionPropertyProvider Create(FieldInfo field)
    {
      var genericType = GetFieldGenericType(field);
      if(genericType == null) return null;

      var genericProviderType = typeof(GenericSourceCollectionPropertyProvider<>).MakeGenericType(genericType);
      var output = Activator.CreateInstance(genericProviderType, field);
      return (GenericSourceCollectionPropertyProvider) output;
    }

    static Type GetFieldGenericType(FieldInfo field)
    {
      if(field == null)
        throw new ArgumentNullException(nameof(field));

      var fieldType = field.FieldType;
      if(!fieldType.IsGenericType || fieldType.GetGenericArguments().Length != 1) return null;

      var interfaces = fieldType.GetGenericTypeDefinition().GetInterfaces();
      var eventRaisingCollectionInterface = interfaces
        .FirstOrDefault(x => x.IsGenericType
                             && x.GetGenericTypeDefinition() == EventRaisingCollectionType);
      if(eventRaisingCollectionInterface == null) return null;

      return fieldType.GetGenericArguments().Single();
    }
  }
}
