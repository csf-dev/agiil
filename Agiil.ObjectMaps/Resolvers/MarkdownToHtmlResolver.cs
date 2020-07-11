using System;
using Agiil.Web.Rendering;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
  public class MarkdownToHtmlResolver : IMemberValueResolver<object, object, string, string>
  {
    readonly IRendersMarkdownToHtml renderer;

    public string Resolve(object source, object destination, string sourceMember, string destMember, ResolutionContext context)
      => renderer.GetHtml(sourceMember);

    public MarkdownToHtmlResolver(IRendersMarkdownToHtml renderer)
    {
      this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
    }
  }
}
