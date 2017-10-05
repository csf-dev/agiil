using System;
using Agiil.Web.Rendering;
using AutoMapper;

namespace Agiil.ObjectMaps.Resolvers
{
  public class MarkdownToHtmlResolver : IMemberValueResolver<object, object, string, string>
  {
    readonly IHtmlRenderer renderer;

    public string Resolve(object source, object destination, string sourceMember, string destMember, ResolutionContext context)
      => renderer.GetHtml(sourceMember);

    public MarkdownToHtmlResolver(IHtmlRenderer renderer)
    {
      if(renderer == null)
        throw new ArgumentNullException(nameof(renderer));
      this.renderer = renderer;
    }
  }
}
