using System;
using System.Web.Mvc;
using Agiil.Web.Services;

namespace Agiil.Web.ActionFilters
{
  public class ObjectSerializerPopulator : IActionFilter
  {
    readonly Func<ISerialisesToJson> serializerFactory;

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
      var viewResult = filterContext.GetResult<ViewResult>();
      if(viewResult == null) return;

      viewResult.ViewBag.JsonSerializer = serializerFactory();
    }

    public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

    public ObjectSerializerPopulator(Func<ISerialisesToJson> serializerFactory)
    {
      if(serializerFactory == null)
        throw new ArgumentNullException(nameof(serializerFactory));

      this.serializerFactory = serializerFactory;
    }
  }
}
