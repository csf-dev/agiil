using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Agiil.Web.Services
{
  public class MvcTempDataProvider : IGetsTempData
  {
    readonly IDictionary<string,object> tempData;

    public object this[string key] => Get(key);

    public object Get(string key)
    {
      bool success;
      var output = TryGet(key, out success);

      if(!success)
        throw new KeyNotFoundException($"The key '{key}' was not found in the temp data.");

      return output;
    }

    public T Get<T>(string key)
    {
      bool success;
      var output = TryGet<T>(key, out success);

      if(!success)
        throw new KeyNotFoundException($"The key '{key}' was not found in the temp data, or its type is not {typeof(T).Name}.");

      return output;
    }

    public object TryGet(string key)
    {
      bool success;
      return TryGet(key, out success);
    }

    public T TryGet<T>(string key)
    {
      bool success;
      return TryGet<T>(key, out success);
    }

    public object TryGet(string key, out bool success)
    {
      return TryGet<object>(key, out success);
    }

    public T TryGet<T>(string key, out bool success)
    {
      if(!tempData.ContainsKey(key))
      {
        success = false;
        return default(T);
      }

      var value = tempData[key];
      if(!(value is T))
      {
        success = false;
        return default(T);
      }

      success = true;
      return (T) value;
    }

    public MvcTempDataProvider(TempDataDictionary tempData)
    {
      if(tempData == null)
        throw new ArgumentNullException(nameof(tempData));
      this.tempData = tempData;
    }
  }
}
