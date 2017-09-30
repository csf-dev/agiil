using System;
using System.Web.Http;
using Agiil.Web.Services.Logging;

namespace Agiil.Web.App_Start
{
  public class WebApiFilterConfiguration
  {
    public void RegisterFilters(HttpConfiguration config)
    {
      config.Filters.Add(new AuthorizeAttribute());
      config.Filters.Add(new LogUnexpectedErrorsAttribute());
    }
  }
}
