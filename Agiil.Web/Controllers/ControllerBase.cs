using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Agiil.Web.App_Start;
using Agiil.Web.Services.SharedModel;
using AutoMapper;

namespace Agiil.Web.Controllers
{
  public abstract class ControllerBase : Controller
  {
    readonly StandardPageModelFactory standardModelFactory;
    readonly Lazy<IMapper> mapper;

    protected StandardPageModelFactory ModelFactory => standardModelFactory;

    protected IMapper Mapper => mapper.Value;

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

    public ControllerBase(ControllerBaseDependencies baseDeps)
    {
      if(baseDeps == null)
        throw new ArgumentNullException(nameof(baseDeps));

      this.standardModelFactory = baseDeps.StandardModelFactory;
      this.mapper = baseDeps.Mapper;
    }
  }
}
