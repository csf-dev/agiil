using System;
using Autofac;

namespace Agiil.Bootstrap
{
  public interface IAutofacContainerFactory
  {
    IContainer GetContainer();

    ContainerBuilder GetContainerBuilder();
  }
}
