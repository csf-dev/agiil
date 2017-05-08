using System;
using Autofac;
using Autofac.Integration.WebApi;
using Agiil.Web.ModelBinders;
using CSF.Entities;

namespace Agiil.Web.Bootstrap
{
  public class WebApiModelBindersModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<IdentityWebApiModelBinder>()
        .AsModelBinderForTypes(typeof(IIdentity<>));
    }
  }
}
