using System;
using log4net;

namespace Agiil.Domain
{
  public interface IGetsLoggerForType
  {
    ILog GetLogger(Type type);
  }
}
