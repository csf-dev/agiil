using System;
using System.Web.Mvc;

namespace Agiil.Web.App_Start
{
  public class MvcGlobalFilterConfiguration
  {
    public void RegisterFilters(GlobalFilterCollection filters)
    {
      filters.Add(new AuthorizeAttribute());

      // This is safe only because I am using ZPT-Sharp to render all user-generated content!
      filters.Add(new ValidateInputAttribute(false));
    }
  }
}
