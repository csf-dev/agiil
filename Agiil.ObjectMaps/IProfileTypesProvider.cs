using System;
using System.Collections.Generic;

namespace Agiil.ObjectMaps
{
  public interface IProfileTypesProvider
  {
    IEnumerable<Type> GetAllProfileTypes();
  }
}
