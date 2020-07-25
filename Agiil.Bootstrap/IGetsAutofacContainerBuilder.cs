using System;
using Autofac;

namespace Agiil.Bootstrap
{
    public interface IGetsAutofacContainerBuilder
    {
        ContainerBuilder GetContainerBuilder();
    }
}
