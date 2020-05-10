using System;
using System.Linq;
using System.Reflection;
using CSF.Collections.EventRaising;
using NHibernate.Properties;

namespace Agiil.Data.ConventionMappings
{
    public class SourceCollectionGetterSetterFactory<TCollectionItem> : SourceCollectionGetterSetterFactory
      where TCollectionItem : class
    {
        readonly FieldInfo field;
        readonly SourceCollectionGetterSetter<TCollectionItem> getterSetter;

        public override IGetter GetGetter() => getterSetter;

        public override ISetter GetSetter() => getterSetter;

        public SourceCollectionGetterSetterFactory(FieldInfo field)
        {
            this.field = field ?? throw new ArgumentNullException(nameof(field));
            getterSetter = new SourceCollectionGetterSetter<TCollectionItem>(field);
        }
    }

    public abstract class SourceCollectionGetterSetterFactory
    {
        static readonly Type EventRaisingCollectionType = typeof(IEventRaisingCollectionWrapper<>);

        public abstract IGetter GetGetter();

        public abstract ISetter GetSetter();

        public static SourceCollectionGetterSetterFactory Create(FieldInfo field)
        {
            var genericType = GetFieldGenericType(field);
            if(genericType == null) return null;

            var genericProviderType = typeof(SourceCollectionGetterSetterFactory<>).MakeGenericType(genericType);
            var output = Activator.CreateInstance(genericProviderType, field);
            return (SourceCollectionGetterSetterFactory) output;
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
