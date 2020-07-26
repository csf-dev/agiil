using System;
using Autofac;
using System.Reflection;
using Agiil.Web.Bootstrap;
using System.Linq;
using Agiil.Bootstrap;
using System.Web.Http;
using Autofac.Core;

namespace Agiil.Web.App_Start
{
    public class WebAppTestingContainerFactory
        : IGetsAutofacContainer, IGetsAutofacContainerBuilder, IGetsAutofacContainerWithOverridableHttpConfiguration
    {
        readonly WebAppContainerFactory wrapped;

        public IContainer GetContainer()
        {
            var containerFactory = new AutofacContainerCreator(this);
            return containerFactory.GetContainer();
        }

        public ContainerBuilder GetContainerBuilder()
        {
            var builder = wrapped.GetContainerBuilder();
            AutoRegisterAssemblyModules(builder);
            builder.RegisterModule(new AspNetWebApiTestBuildModule(HttpConfig));
            return builder;
        }

        public HttpConfiguration HttpConfig
        {
            get => wrapped.HttpConfig;
            set => wrapped.HttpConfig = value;
        }

        void AutoRegisterAssemblyModules(ContainerBuilder builder)
        {
            var modulesToAutoRegister = Assembly.GetExecutingAssembly()
                .GetExportedTypes()
                .Where(x => x.IsClass
                            && !x.IsAbstract
                            && typeof(Autofac.Module).IsAssignableFrom(x)
                            && x.GetConstructor(Type.EmptyTypes) != null
                            && x != typeof(AspNetWebApiTestBuildModule))
                .Select(x => Activator.CreateInstance(x))
                .Cast<IModule>()
                .ToList();

            foreach(var module in modulesToAutoRegister)
                builder.RegisterModule(module);
        }

        public WebAppTestingContainerFactory()
        {
            wrapped = new WebAppContainerFactory(false);
        }
    }
}
