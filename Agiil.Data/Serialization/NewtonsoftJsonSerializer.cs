using System;
using System.IO;
using System.Text;
using Agiil.Domain.Data;
using Newtonsoft.Json;

namespace Agiil.Data.Serialization
{
  public class NewtonsoftJsonSerializer : ISerializesToFromString
  {
    readonly JsonSerializer serializer;

    public T Deserialize<T>(string serialized)
    {
      if(String.IsNullOrEmpty(serialized)) return default(T);

      using(var reader = new StringReader(serialized))
      {
        return Deserialize<T>(reader);
      }
    }

    public T Deserialize<T>(TextReader reader)
    {
      using(var jsonReader = new JsonTextReader(reader))
      {
        return serializer.Deserialize<T>(jsonReader);
      }
    }

    public string Serialize<T>(T obj)
    {
      var builder = new StringBuilder();

      using(var writer = new StringWriter(builder))
      {
        Serialize(obj, writer);
      }

      return builder.ToString();
    }

    public void Serialize<T>(T obj, TextWriter writer)
    {
      using(var jsonWriter = new JsonTextWriter(writer))
      {
        serializer.Serialize(jsonWriter, obj);
      }
    }

    public NewtonsoftJsonSerializer(JsonSerializer serializer = null)
    {
      this.serializer = serializer ?? new JsonSerializer();
    }
  }
}
