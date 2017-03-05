using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Agiil.Web.Controllers
{
  public abstract class ControllerBase : Controller
  {
    #region fields

    const string ControllerNamePattern = "^(.+)Controller$";
    static readonly Regex ControllerNameMatcher = new Regex(ControllerNamePattern, RegexOptions.Compiled);

    #endregion

    protected virtual string GetControllerName<TController>() where TController : Controller
    {
      var typeName = typeof(TController).Name;
      var match = ControllerNameMatcher.Match(typeName);
      if(match.Success)
      {
        return match.Groups[1].Value;
      }

      return typeName;
    }
  }
}
