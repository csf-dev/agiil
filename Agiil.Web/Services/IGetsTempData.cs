using System;
using System.Web.Mvc;

namespace Agiil.Web.Services
{
  public interface IGetsTempData
  {
    object Get(string key);
    T Get<T>(string key);

    object TryGet(string key);
    T TryGet<T>(string key);
    object TryGet(string key, out bool success);
    T TryGet<T>(string key, out bool success);

    object this [string key] { get; }
  }
}
