using System;
using Autofac;

namespace Agiil.Bootstrap
{
  public interface IAutofacContainerBuilderFactory
  {
    ContainerBuilder GetContainerBuilder();
  }
}
