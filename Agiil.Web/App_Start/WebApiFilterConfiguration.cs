using System;
using System.Web.Http;

namespace Agiil.Web.App_Start
{
  public class WebApiFilterConfiguration
  {
    public void RegisterFilters(HttpConfiguration config)
    {
      config.Filters.Add(new AuthorizeAttribute());
    }
  }
}
