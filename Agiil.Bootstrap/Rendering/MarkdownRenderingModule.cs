using System;
using Agiil.Web.Rendering;
using Autofac;

namespace Agiil.Bootstrap.Rendering
{
  public class MarkdownRenderingModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<CommonMarkHtmlRenderer>()
        .As<IHtmlRenderer>();
    }
  }
}
