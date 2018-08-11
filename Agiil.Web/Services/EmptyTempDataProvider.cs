using System;
namespace Agiil.Web.Services
{
  public class EmptyTempDataProvider : IGetsTempData
  {
    public object this[string key] => Get(key);

    public object Get(string key) => Get<object>(key);

    public T Get<T>(string key) => throw new NotSupportedException("This implementation does not expose any data.");

    public object TryGet(string key)
    {
      bool success;
      return TryGet<object>(key, out success);
    }

    public T TryGet<T>(string key)
    {
      bool success;
      return TryGet<T>(key, out success);
    }

    public object TryGet(string key, out bool success) => TryGet<object>(key, out success);

    public T TryGet<T>(string key, out bool success)
    {
      success = false;
      return default(T);
    }
  }
}
