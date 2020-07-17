using System;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace Agiil.Web.ApiActionFilters
{
    public class Log4netUnexpectedErrorLogger : ExceptionLogger
    {
        readonly static ILog logger;

        public override void Log(ExceptionLoggerContext context)
        {
            logger.Error($@"Unhandled exception at {context.Request.RequestUri}
{context.Exception}");
        }

        static Log4netUnexpectedErrorLogger()
        {
            logger = LogManager.GetLogger(typeof(Log4netUnexpectedErrorLogger));
        }
    }
}
