using System;
using Autofac;

namespace Agiil.Bootstrap
{
  public interface IGetsAutofacContainer
  {
    IContainer GetContainer();

    ContainerBuilder GetContainerBuilder();
  }
}
