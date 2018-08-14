using System;
using Autofac;

namespace Agiil.Bootstrap
{
  public interface IRegistersModulesInBulk
  {
    void RegisterModules(ContainerBuilder builder);
  }
}
