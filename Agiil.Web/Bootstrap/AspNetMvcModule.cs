using System;
using System.Web.Mvc;
using Agiil.Web.ModelBinders;
using Autofac;
using Autofac.Integration.Mvc;

namespace Agiil.Web.Bootstrap
{
  public class AspNetMvcModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = System.Reflection.Assembly.GetExecutingAssembly();

      builder.RegisterControllers(assembly);
      builder.RegisterModelBinders(assembly);

      builder
        .RegisterType<AutofacMvcModelBinderProviderWithOpenGenericSupport>()
        .As<IModelBinderProvider>()
        .SingleInstance();
      
      builder.RegisterModule<AutofacWebTypesModule>();
    }
  }
}
