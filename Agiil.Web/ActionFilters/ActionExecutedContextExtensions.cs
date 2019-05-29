using System;
using System.Web.Mvc;

namespace Agiil.Web.ActionFilters
{
  public static class ActionExecutedContextExtensions
  {
    public static T GetResult<T>(this ActionExecutedContext context) where T : ActionResult
    {
      if(context == null)
        throw new ArgumentNullException(nameof(context));

      return context.Result as T;
    }
  }
}
