using System;
namespace Agiil.Web.Services
{
  public class TempDataContainer : IGetsTempData
  {
    IGetsTempData wrapped;

    public object this[string key] => wrapped[key];

    public object Get(string key)
    {
      return wrapped.Get(key);
    }

    public T Get<T>(string key)
    {
      return wrapped.Get<T>(key);
    }

    public object TryGet(string key)
    {
      return wrapped.TryGet(key);
    }

    public T TryGet<T>(string key)
    {
      return wrapped.TryGet<T>(key);
    }

    public object TryGet(string key, out bool success)
    {
      return wrapped.TryGet(key, out success);
    }

    public T TryGet<T>(string key, out bool success)
    {
      return wrapped.TryGet<T>(key, out success);
    }

    public void InjectTempDataProvider(IGetsTempData provider)
    {
      if(provider == null)
        throw new ArgumentNullException(nameof(provider));
      wrapped = provider;
    }

    public TempDataContainer(EmptyTempDataProvider emptyProvider)
    {
      if(emptyProvider == null)
        throw new ArgumentNullException(nameof(emptyProvider));
      
      wrapped = emptyProvider;
    }
  }
}
