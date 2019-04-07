using System;
using log4net;

namespace Agiil.Domain
{
  public class Log4NetLoggerForTypeProvider : IGetsLoggerForType
  {
    public ILog GetLogger(Type type) => LogManager.GetLogger(type);
  }
}
