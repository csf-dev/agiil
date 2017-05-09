using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Agiil.Web.App_Start;
using Agiil.Web.Services.SharedModel;

namespace Agiil.Web.Controllers
{
  public abstract class ControllerBase : Controller
  {
    readonly StandardPageModelFactory standardModelFactory;

    protected StandardPageModelFactory ModelFactory => standardModelFactory;

    protected virtual string GetControllerName<TController>() where TController : Controller
    {
      return RouteConfiguration.GetControllerName<TController>();
    }

    protected virtual T GetTempData<T>(string key) where T : class
    {
      object data;

      if(TempData.TryGetValue(key, out data))
      {
        return (T) data;
      }

      return null;
    }

    protected virtual T? GetNullableTempData<T>(string key) where T : struct
    {
      object data;

      if(TempData.TryGetValue(key, out data))
      {
        return (T) data;
      }

      return null;
    }

    public ControllerBase(StandardPageModelFactory standardModelFactory)
    {
      if(standardModelFactory == null)
        throw new ArgumentNullException(nameof(standardModelFactory));

      this.standardModelFactory = standardModelFactory;
    }
  }
}
