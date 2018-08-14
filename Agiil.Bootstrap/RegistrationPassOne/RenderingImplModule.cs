using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class RenderingImplModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      BulkRegistrationHelper.Default.RegisterAll<Web.Rendering.MarkdownRenderer>(builder);
    }
  }
}
