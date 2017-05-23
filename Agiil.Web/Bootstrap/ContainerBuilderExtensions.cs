using System;
using System.Configuration;
using Autofac;
using Autofac.Builder;
using CSF.Configuration;

namespace Agiil.Web.Bootstrap
{
  public static class ContainerBuilderExtensions
  {
    public static IRegistrationBuilder<T,SimpleActivatorData,SingleRegistrationStyle> RegisterConfiguration<T>(this ContainerBuilder builder)
      where T : ConfigurationSection
    {
      return builder.Register(ctx => {
        var configReader = ctx.Resolve<IConfigurationReader>();
        return configReader.ReadSection<T>();
      });
    }

    public static IRegistrationBuilder<T,SimpleActivatorData,SingleRegistrationStyle> RegisterConfiguration<T>(this ContainerBuilder builder,
                                                                                                               string path)
      where T : ConfigurationSection
    {
      return builder.Register(ctx => {
        var configReader = ctx.Resolve<IConfigurationReader>();
        return configReader.ReadSection<T>(path);
      });
    }
  }
}
