using System;
using System.Web.Mvc;

namespace Agiil.Web.App_Start
{
  public class MvcGlobalFilterConfiguration
  {
    public void RegisterFilters(GlobalFilterCollection filters)
    {
      filters.Add(new AuthorizeAttribute());
    }
  }
}
