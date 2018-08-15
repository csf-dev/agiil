using System;
using System.Collections.Generic;

namespace Agiil.Bootstrap
{
  public interface IGetsTypes
  {
    IEnumerable<Type> GetTypes<T>();
  }
}
