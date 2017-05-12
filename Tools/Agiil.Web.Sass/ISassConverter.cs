using System;
using SharpScss;

namespace Agiil.Web.Sass
{
  public interface ISassConverter
  {
    void Convert(string inputPath, string outputPath, ScssOptions options);
  }
}
