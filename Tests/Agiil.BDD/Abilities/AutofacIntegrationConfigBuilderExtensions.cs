using System;
using Agiil.Bootstrap;
using CSF.Screenplay.Integration;

namespace Agiil.BDD.Abilities
{
  public static class AutofacIntegrationConfigBuilderExtensions
  {
    public static void UseAutofacContainer(this IIntegrationConfigBuilder builder)
    {
      if(builder == null)
        throw new ArgumentNullException(nameof(builder));

      builder.ServiceRegistrations.PerTestRun.Add(reg => {
        reg.RegisterFactory(GetContainer<Web.App_Start.WebAppTestingContainerFactory>);
      });
    }

    static Autofac.IContainer GetContainer<TProvider>() where TProvider : IGetsAutofacContainer, new()
      => new TProvider().GetContainer();
  }
}
