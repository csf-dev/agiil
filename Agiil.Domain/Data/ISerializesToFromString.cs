using System;
using System.IO;

namespace Agiil.Domain.Data
{
  public interface ISerializesToFromString
  {
    string Serialize<T>(T obj);
    void Serialize<T>(T obj, TextWriter writer);

    T Deserialize<T>(string serialized);
    T Deserialize<T>(TextReader reader);
  }
}
