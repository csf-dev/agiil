﻿using System;
using System.Web.Http;
using Agiil.Web.ApiActionFilters;

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
