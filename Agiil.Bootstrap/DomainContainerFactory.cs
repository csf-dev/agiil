using System;
using System.Reflection;
using Autofac;
using log4net;

namespace Agiil.Bootstrap
{
    public class DomainContainerFactory : IGetsAutofacContainer, IGetsAutofacContainerBuilder
    {
        public IContainer GetContainer()
        {
            var containerFactory = new AutofacContainerCreator(this);
            return containerFactory.GetContainer();
        }

        public ContainerBuilder GetContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            return builder;
        }
    }
}
