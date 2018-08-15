using System;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace Agiil.Web.Bootstrap
{
  [Agiil.Bootstrap.DoNotAutoRegister]
  public class AspNetWebApiTestBuildModule : AspNetWebApiModule
  {
    protected override void RegisterControllers(Autofac.ContainerBuilder builder)
    {
      var assemblies = new [] {
        typeof(AspNetWebApiModule).Assembly,
        System.Reflection.Assembly.GetExecutingAssembly(),
      };

      builder.RegisterApiControllers(assemblies);
    }

    public AspNetWebApiTestBuildModule(HttpConfiguration config) : base(config) { }
  }
}
