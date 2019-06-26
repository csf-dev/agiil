using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Agiil.Web.Services
{
  public class NewtonsoftJsonObjectSerialiser : ISerialisesToJson
  {
    readonly JsonSerializer serializer;

    public string Serialize(object obj)
    {
      if(obj == null)
        throw new ArgumentNullException(nameof(obj));

      var builder = new StringBuilder();

      using(var tWriter = new StringWriter(builder))
      using(var jWriter = new JsonTextWriter(tWriter))
      {
        serializer.Serialize(jWriter, obj);
      }

      return builder.ToString();
    }

    public NewtonsoftJsonObjectSerialiser()
    {
      serializer = new JsonSerializer();
    }
  }
}
