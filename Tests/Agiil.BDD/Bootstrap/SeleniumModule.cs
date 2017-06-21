using System;
using Autofac;
using CSF.WebDriverFactory;

namespace Agiil.BDD.Bootstrap
{
  public class SeleniumModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<ConfigurationWebDriverFactoryProvider>()
        .As<IWebDriverFactoryProvider>();

      builder.Register(ctx => ctx.Resolve<IWebDriverFactoryProvider>().GetFactory());
    }
  }
}
