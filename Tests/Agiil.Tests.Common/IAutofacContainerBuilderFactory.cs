using System;
using Autofac;

namespace Agiil.Tests.Common
{
  public interface IAutofacContainerBuilderFactory
  {
    ContainerBuilder GetContainerBuilder();
  }
}
