using Agiil.Bootstrap;
using Agiil.Web.Services;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  [RegistrationOrder(1)]
  public class ServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      BulkRegistrationHelper.Default.RegisterAll<IServicesNamespaceMarker>(builder);
    }
  }
}
