using System;
using System.Web.Mvc;
using Agiil.Domain;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Services
{
  public class BaseUriModelPopulator : IActionFilter
  {
    readonly IProvidesApplicationBaseUri baseUriProvider;

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
      var viewResult = filterContext.Result as ViewResult;
      if(viewResult == null) return;

      var baseUriModel = viewResult.Model as IHasBaseUri;
      if(baseUriModel == null) return;

      Populate(baseUriModel);
    }

    public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

    void Populate(IHasBaseUri model)
    {
      model.BaseUri = new BaseUriModel {
        Uri = baseUriProvider.GetBaseUri()
      };
    }

    public BaseUriModelPopulator(IProvidesApplicationBaseUri baseUriProvider)
    {
      if(baseUriProvider == null)
        throw new ArgumentNullException(nameof(baseUriProvider));
      this.baseUriProvider = baseUriProvider;
    }
  }
}
