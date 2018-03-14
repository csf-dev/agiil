using System;
using System.Web.Http.Filters;
using log4net;

namespace Agiil.Web.Services.Logging
{
  public class LogUnexpectedErrorsAttribute : ExceptionFilterAttribute
  {
    readonly static ILog logger;

    public override void OnException(HttpActionExecutedContext actionExecutedContext)
    {
      var exception = actionExecutedContext.Exception;
      if(exception == null)
        logger.Error("Unhandled exception in API action, but the exception instance is <null>.");

      logger.Error("Unhandled exception in API action", exception);
    }

    static LogUnexpectedErrorsAttribute()
    {
      logger = LogManager.GetLogger(typeof(LogUnexpectedErrorsAttribute));
    }
  }
}
