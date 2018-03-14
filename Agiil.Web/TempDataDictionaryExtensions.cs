using System;
using System.Web.Mvc;

namespace Agiil.Web
{
  public static class TempDataDictionaryExtensions
  {
    public static T Get<T>(this TempDataDictionary tempData, string key)
    {
      if(tempData == null)
        throw new ArgumentNullException(nameof(tempData));

      object data;
      if(tempData.TryGetValue(key, out data))
        return (T) data;

      throw new InvalidOperationException($"The data dictionary does not contain a value for the key '{key}'.");
    }

    public static T TryGet<T>(this TempDataDictionary tempData, string key) where T : class
    {
      if(tempData == null)
        throw new ArgumentNullException(nameof(tempData));

      object data;
      if(tempData.TryGetValue(key, out data))
        return (T) data;

      return null;
    }

    public static T? TryGetNullable<T>(this TempDataDictionary tempData, string key) where T : struct
    {
      if(tempData == null)
        throw new ArgumentNullException(nameof(tempData));

      object data;
      if(tempData.TryGetValue(key, out data))
        return (T) data;

      return null;
    }
  }
}
