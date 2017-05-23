using System;
using Autofac;

namespace Agiil.Bootstrap
{
  public interface IDiConfiguration
  {
    ContainerBuilder GetContainerBuilder();
  }
}
