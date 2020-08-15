using System;
using System.Reflection;
using System.Web.Http;
using Agiil.Bootstrap;
using Autofac;
using System.Linq;
using Agiil.Web.Bootstrap;
using Autofac.Core;

namespace Agiil.Web.App_Start
{
    public class WebAppContainerFactory : IGetsAutofacContainer, IGetsAutofacContainerBuilder, IGetsAutofacContainerWithOverridableHttpConfiguration
    {
        readonly IGetsAutofacContainerBuilder wrapped;
        readonly bool registerApiControllers;
        HttpConfiguration httpConfig;

        public HttpConfiguration HttpConfig
        {
            get => httpConfig;
            set => httpConfig = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IContainer GetContainer()
        {
            var containerFactory = new AutofacContainerCreator(this);
            return containerFactory.GetContainer();
        }

        public ContainerBuilder GetContainerBuilder()
        {
            var builder = wrapped.GetContainerBuilder();

            AutoRegisterAssemblyModules(builder);
            if(registerApiControllers)
                builder.RegisterModule(new AspNetWebApiModule(HttpConfig));
            builder.RegisterModule<AspNetMvcModule>();

            return builder;
        }

        void AutoRegisterAssemblyModules(ContainerBuilder builder)
        {
            var modulesToAutoRegister = Assembly.GetExecutingAssembly()
                .GetExportedTypes()
                .Where(x => x.IsClass
                            && !x.IsAbstract
                            && typeof(Autofac.Module).IsAssignableFrom(x)
                            && x.GetConstructor(Type.EmptyTypes) != null
                            && x != typeof(AspNetMvcModule))
                .Select(x => Activator.CreateInstance(x))
                .Cast<IModule>()
                .ToList();

            foreach(var module in modulesToAutoRegister)
                builder.RegisterModule(module);
        }

        public WebAppContainerFactory()
        {
            httpConfig = new HttpConfiguration();
            wrapped = new DomainContainerFactory();
            registerApiControllers = true;
        }

        public WebAppContainerFactory(bool registerApiControllers) : this()
        {
            this.registerApiControllers = registerApiControllers;
        }
    }
}
