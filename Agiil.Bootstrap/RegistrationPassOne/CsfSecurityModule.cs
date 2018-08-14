using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class CsfSecurityModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      BulkRegistrationHelper.Default.RegisterAll<CSF.Security.Authentication.IPassword>(builder);
    }
  }
}
