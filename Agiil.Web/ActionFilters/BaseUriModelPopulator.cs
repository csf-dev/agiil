using System;
using System.Web.Mvc;
using Agiil.Domain;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.ActionFilters
{
  public class BaseUriModelPopulator : IActionFilter
  {
    readonly IProvidesApplicationBaseUri baseUriProvider;

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
      var viewResult = filterContext.Result as ViewResult;
      if(viewResult == null) return;

      viewResult.ViewBag.BaseUri = new BaseUriModel {
          Uri = baseUriProvider.GetBaseUri()
      };
    }

    public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

    public BaseUriModelPopulator(IProvidesApplicationBaseUri baseUriProvider)
    {
      if(baseUriProvider == null)
        throw new ArgumentNullException(nameof(baseUriProvider));
      this.baseUriProvider = baseUriProvider;
    }
  }
}
