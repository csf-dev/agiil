﻿using System.Web;
using System.Web.Mvc;
using System;
using log4net;

namespace Agiil.Web
{
  public class Global : HttpApplication
  {
    static readonly ILog logger;

    protected void Application_Start()
    {
      logger.Info($"The Agiil {nameof(HttpApplication)} is starting up");
      AreaRegistration.RegisterAllAreas();
    }

    protected void Application_Error(Object sender, EventArgs e)
    {
      var ex = Server.GetLastError();
      logger.Error("Unhandled exception", ex);
    }

    static Global()
    {
      logger = LogManager.GetLogger(typeof(Global));
    }
  }
}
