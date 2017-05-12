using System;
using System.IO;
using SharpScss;

namespace Agiil.Web.Sass
{
  public class SharpScssConverter : ISassConverter
  {
    const string OutputMapExtension = ".map";

    public void Convert(string inputPath, string outputPath, ScssOptions options)
    {
      var result = Scss.ConvertFileToCss(inputPath, options);
      WriteCssFile(result.Css, outputPath);
      WriteSourceMap(result.SourceMap, outputPath);
    }

    void WriteCssFile(string css, string outputPath)
    {
      using(var writer = File.CreateText(outputPath))
      {
        writer.WriteLine(css);
      }
    }

    void WriteSourceMap(string map, string outputPath)
    {
      if(map == null)
        return;
      
      using(var writer = File.CreateText(outputPath + OutputMapExtension))
      {
        writer.WriteLine(map);
      }
    }
  }
}
