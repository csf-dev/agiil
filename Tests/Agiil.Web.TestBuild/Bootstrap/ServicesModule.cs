using Agiil.Bootstrap;
using Agiil.Web.Services;
using Agiil.Web.Services.DataPackages;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  [RegistrationOrder(1)]
  public class ServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      BulkRegistrationHelper.Default.RegisterAllExcept<IServicesNamespaceMarker>(builder,
                                                                                 typeof(SimpleSampleProject));
    }
  }
}
