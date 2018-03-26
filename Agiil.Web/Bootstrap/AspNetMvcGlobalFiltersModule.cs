using System;
using System.Web.Mvc;
using Agiil.Web.Services;
using Autofac;
using Autofac.Integration.Mvc;

namespace Agiil.Web.Bootstrap
{
  public class AspNetMvcGlobalFiltersModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .Register(c => new AuthorizeAttribute())
        .AsAuthorizationFilterFor<Controller>()
        .InstancePerRequest();
      
      // I'm globally switching off validation of input into the application.
      // This is only safe because I am always ensuring that I am rendering all user-generated
      // content either using ZPT-Sharp (which HTML encodes by default), or I am using
      // markdown rendering (into which I have already added HTML sanitisation) and
      // I am NEVER rendering user-entered data anywhere that isn't directly into HTML
      // body (EG: into an attribute, or script tag, or style tag etc).
      builder
        .Register(c => new ValidateInputAttribute(false))
        .AsAuthorizationFilterFor<Controller>()
        .InstancePerRequest();

      builder
        .Register(c => new LoginStateModelPopulator(c.Resolve<LoginStateReader>()))
        .AsActionFilterFor<Controller>()
        .InstancePerRequest();

      builder
        .Register(c => new VersionInfoModelPopulator(c.Resolve<Domain.IProvidesVersionInformation>()))
        .AsActionFilterFor<Controller>()
        .InstancePerRequest();
    }
  }
}
