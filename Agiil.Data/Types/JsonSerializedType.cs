using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Agiil.Data.Serialization;
using Agiil.Domain.Data;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace Agiil.Data.Types
{
  public class JsonSerializedType<T> : IUserType, IParameterizedType
  {
    readonly ISerializesToFromString serializer;

    public bool AllowNull { get; set; }

    public SqlType[] SqlTypes => new [] { new SqlType(DbType.String) };

    public Type ReturnedType => typeof(T);

    public bool IsMutable => false;

    public object Assemble(object cached, object owner) => cached;

    public object DeepCopy(object value)
    {
      if(ReferenceEquals(value, null)) return null;
      if(!(value is T)) return null;

      // Copy the object by serializing and then deserializing it
      return serializer.Deserialize<T>(serializer.Serialize<T>((T) value));
    }

    public object Disassemble(object value) => value;

    public new bool Equals(object x, object y)
    {
      if(ReferenceEquals(x, y)) return true;
      if(ReferenceEquals(x, null)) return false;
      if(ReferenceEquals(y, null)) return false;
      if(!(x is T)) return false;
      if(!(y is T)) return false;

      var serializedX = serializer.Serialize((T) x);
      var serializedY = serializer.Serialize((T) y);

      return String.Equals(x, y);
    }

    public int GetHashCode(object x)
    {
      if(ReferenceEquals(x, null)) return 0;
      if(!(x is T)) return x.GetHashCode();

      return serializer.Serialize((T) x).GetHashCode();
    }

    public object NullSafeGet(IDataReader rs, string[] names, object owner)
    {
      var val = (string) NHibernateUtil.String.NullSafeGet(rs, names.First());
      var output = serializer.Deserialize<T>(val);

      if(ReferenceEquals(output, null) && !AllowNull)
        return Activator.CreateInstance<T>();

      return output;
    }

    public void NullSafeSet(IDbCommand cmd, object value, int index)
    {
      if(AllowNull && ReferenceEquals(value, null))
      {
        NHibernateUtil.String.NullSafeSet(cmd, null, index);
        return;
      }

      var val = (T) (value ?? Activator.CreateInstance<T>());
      NHibernateUtil.String.NullSafeSet(cmd, serializer.Serialize(val), index);
    }

    public object Replace(object original, object target, object owner) => original;

    public void SetParameterValues(IDictionary<string, string> parameters)
    {
      if(ReferenceEquals(parameters, null)) return;

      if(parameters.TryGetValue(nameof(AllowNull), out var value))
        AllowNull = value?.ToLowerInvariant() == Boolean.TrueString.ToLowerInvariant();
    }

    public JsonSerializedType()
    {
      var jsonSerializer = new JsonSerializer {
        Formatting = Formatting.None,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
        ContractResolver = new OrderedPropertiesContractResolver()
      };

      serializer = new NewtonsoftJsonSerializer(jsonSerializer);
    }
  }
}
