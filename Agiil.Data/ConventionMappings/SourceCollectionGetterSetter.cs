using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NHibernate.Engine;
using NHibernate.Properties;
using CSF.Collections.EventRaising;

namespace Agiil.Data.ConventionMappings
{
  public class SourceCollectionGetterSetter<TCollectionItem> : IGetter, ISetter where TCollectionItem : class
  {
    readonly FieldInfo field;

    public Type ReturnType => typeof(ICollection<TCollectionItem>);

    public string PropertyName => null;

    public MethodInfo Method => null;

    public object Get(object target)
    {
      var wrapper = GetWrapper(target);
      return wrapper.SourceCollection;
    }

    public object GetForInsert(object owner, IDictionary mergeMap, ISessionImplementor session)
      => Get(owner);

    public void Set(object target, object value)
    {
      var wrapper = GetWrapper(target);
      wrapper.SourceCollection = (ICollection<TCollectionItem>) value;
    }

    IEventRaisingCollectionWrapper<TCollectionItem> GetWrapper(object target)
    {
      if(target == null) throw new ArgumentNullException(nameof(target));
      return (IEventRaisingCollectionWrapper<TCollectionItem>) field.GetValue(target);
    }

    public SourceCollectionGetterSetter(FieldInfo field)
    {
      this.field = field ?? throw new ArgumentNullException(nameof(field));
    }
  }
}
