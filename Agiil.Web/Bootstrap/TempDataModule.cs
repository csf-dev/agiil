using System;
using System.Web.Mvc;
using Agiil.Web.Services;
using Autofac;
using Autofac.Core;

namespace Agiil.Web.Bootstrap
{
  public class TempDataModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      builder.RegisterType<MvcTempDataProvider>();
      builder.RegisterType<EmptyTempDataProvider>();
      builder
        .RegisterType<TempDataContainer>()
        .AsSelf()
        .As<IGetsTempData>()
        .InstancePerRequest();

      base.Load(builder);
    }

		protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
                                                          IComponentRegistration registration)
		{
      registration.Activated += GetTempDataFromMvcControllers;
		}

    void GetTempDataFromMvcControllers(object sender, ActivatedEventArgs<object> args)
    {
      var controller = args.Instance as Controller;
      if(controller == null) return;

      var tempDataParam = GetTempDataParameter(controller);
      if(tempDataParam == null) return;

      InjectTempDataIntoContainerComponent(tempDataParam, args.Context);
    }

    Parameter GetTempDataParameter(Controller controller)
    {
      var tempData = controller.TempData;
      if(tempData == null) return null;
      return new TypedParameter(typeof(TempDataDictionary), tempData);
    }

    void InjectTempDataIntoContainerComponent(Parameter tempDataParam, IComponentContext context)
    {
      var container = context.Resolve<TempDataContainer>();
      var provider = context.Resolve<MvcTempDataProvider>(tempDataParam);
      container.InjectTempDataProvider(provider);
    }
	}
}
