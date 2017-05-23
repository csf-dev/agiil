using System;
namespace Agiil.Web.Sass
{
  public interface ISassCompiler
  {
    void Compile(SassCompilationOptions options);
  }
}
