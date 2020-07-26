using System;
using System.Web.Http;
using Agiil.Bootstrap.DiConfiguration;
using Autofac;

namespace Agiil.Web.App_Start
{
    public static class ContainerFactoryProviderExtensions
    {
        public static IContainer GetContainer(this ContainerFactoryProvider provider, HttpConfiguration config)
        {
            if(provider == null)
                throw new ArgumentNullException(nameof(provider));

            var diFactory = provider.GetContainerBuilderFactory() as IGetsAutofacContainerWithOverridableHttpConfiguration;
            if(diFactory == null)
                throw new InvalidOperationException($"The configured container builder factory must implement {nameof(IGetsAutofacContainerWithOverridableHttpConfiguration)}.");

            diFactory.HttpConfig = config ?? throw new ArgumentNullException(nameof(config));
            return diFactory.GetContainer();
        }
    }
}
