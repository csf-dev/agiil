using System;
using System.Web.Mvc;
using Agiil.Web.ActionFilters;
using Autofac;
using Autofac.Integration.Mvc;

namespace Agiil.Web.Bootstrap
{
  public class AspNetMvcGlobalFiltersModule : Module
  {
    static readonly Type[] GlobalActionFilterTypes = new [] {
      typeof(TestApplicationDependencies),
      typeof(LoginStateModelPopulator),
      typeof(VersionInfoModelPopulator),
      typeof(BaseUriModelPopulator),
      typeof(ObjectSerializerPopulator),
    };

    protected override void Load(ContainerBuilder builder)
    {
      GloballyRequireAuthentication(builder);
      GloballyDisableInputValidation(builder);
      RegisterGlobalActionFilters(builder);
    }

    /// <summary>
    /// Registers <see cref="ValidateInputAttribute"/> for all controllers with a setting of <c>false</c>, which disables
    /// input validation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// I'm globally switching off validation of input into the application.
    /// This is only safe because I am always ensuring that I am rendering all user-generated
    /// content either using ZPT-Sharp (which HTML encodes by default), or I am using
    /// markdown rendering (into which I have already added HTML sanitisation) and
    /// I am NEVER rendering user-entered data anywhere that isn't directly into HTML
    /// body (EG: into an attribute, or script tag, or style tag etc).
    /// </para>
    /// </remarks>
    /// <param name="builder">Builder.</param>
    void GloballyDisableInputValidation(ContainerBuilder builder)
    {
      builder
        .Register(c => new ValidateInputAttribute(false))
        .AsAuthorizationFilterFor<Controller>()
        .InstancePerRequest();
    }

    void GloballyRequireAuthentication(ContainerBuilder builder)
    {
      builder
        .Register(c => new AuthorizeAttribute())
        .AsAuthorizationFilterFor<Controller>()
        .InstancePerRequest();
    }

    void RegisterGlobalActionFilters(ContainerBuilder builder)
    {
      foreach(var type in GlobalActionFilterTypes)
      {
        builder
          .RegisterType(type)
          .AsActionFilterFor<Controller>()
          .InstancePerRequest();
      }
    }
  }
}
