using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class CsfConfigurationModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      BulkRegistrationHelper.Default.RegisterAll<CSF.Configuration.IConfigurationReader>(builder);
    }
  }
}
