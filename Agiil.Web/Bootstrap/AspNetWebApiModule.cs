using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Agiil.Web.ApiActionFilters;
using Agiil.Web.ModelBinders;
using Autofac;
using Autofac.Integration.WebApi;

namespace Agiil.Web.Bootstrap
{
    [Agiil.Bootstrap.DoNotAutoRegister]
    public class AspNetWebApiModule : Module
    {
        readonly HttpConfiguration config;

        protected override void Load(ContainerBuilder builder)
        {
            RegisterControllers(builder);
            RegisterFilterProvider(builder);
            RegisterModelBinder(builder);

            builder.RegisterType<Log4netUnexpectedErrorLogger>().AsSelf().AsImplementedInterfaces();
        }

        protected virtual void RegisterControllers(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assembly);
        }

        protected virtual void RegisterFilterProvider(ContainerBuilder builder)
        {
            builder.RegisterWebApiFilterProvider(config);
        }

        protected virtual void RegisterModelBinder(ContainerBuilder builder)
        {
            builder
              .RegisterType<AutofacWebApiModelBinderProviderWithOpenGenericSupport>()
              .As<ModelBinderProvider>();
        }

        public AspNetWebApiModule(HttpConfiguration config)
        {
            if(config == null)
                throw new ArgumentNullException(nameof(config));

            this.config = config;
        }
    }
}
