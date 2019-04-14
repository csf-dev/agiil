using System;
using System.Collections.Concurrent;
using log4net;

namespace Agiil.Domain
{
  public class CachingLogForTypeDecorator : IGetsLoggerForType
  {
    readonly ConcurrentDictionary<Type,ILog> cache;
    readonly IGetsLoggerForType wrapped;

    public ILog GetLogger(Type type) => cache.GetOrAdd(type, t => wrapped.GetLogger(t));

    public CachingLogForTypeDecorator(IGetsLoggerForType wrapped)
    {
      cache = new ConcurrentDictionary<Type,ILog>();
      this.wrapped = wrapped;
    }
  }
}
