using System;
using Autofac;

namespace Agiil.Bootstrap.Config
{
  public class ConfigurationModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<CSF.Configuration.ConfigurationReader>()
        .As<CSF.Configuration.IConfigurationReader>();
    }
  }
}
