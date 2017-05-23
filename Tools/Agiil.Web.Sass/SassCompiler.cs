using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SharpScss;

namespace Agiil.Web.Sass
{
  public class SassCompiler : ISassCompiler
  {
    const string SassExtension = ".scss", CssExtension = ".css";
    readonly ISassConverter converter;

    public void Compile(SassCompilationOptions options)
    {
      if(options == null)
        throw new ArgumentNullException(nameof(options));
      if(options.SourceDirectory == null)
        throw new ArgumentException("Source directory must not be null", nameof(options));
      if(options.OutputDirectory == null)
        throw new ArgumentException("Output directory must not be null", nameof(options));

      var filesToCompile = GetFilesToCompile(options.SourceDirectory, options.FileMatcher);

      foreach(var file in filesToCompile)
      {
        Compile(file, options.OutputDirectory);
      }
    }

    IEnumerable<FileInfo> GetFilesToCompile(DirectoryInfo directory, Func<string,bool> matcher)
    {
      if(directory == null)
        throw new ArgumentNullException(nameof(directory));
      
      return (from file in directory.GetFiles($"*{SassExtension}")
              where
                file.Extension == SassExtension
                && (matcher == null || matcher(file.Name))
              select file)
        .ToArray();
    }

    void Compile(FileInfo file, DirectoryInfo outputDirectory)
    {
      var options = GetDefaultOptions();

      var outputPath = GetOutputPath(file, outputDirectory);
      options.OutputFile = outputPath;

      converter.Convert(file.FullName, outputPath, options);
    }

    ScssOptions GetDefaultOptions()
    {
      var options = new ScssOptions
      {
        OutputStyle = ScssOutputStyle.Expanded,
        Linefeed = Environment.NewLine,
      };

      #if DEBUG
      options.GenerateSourceMap = true;
      options.SourceComments = true;
      #endif

      return options;
    }

    string GetOutputPath(FileInfo inputFile, DirectoryInfo outputDirectory)
    {
      var oldName = inputFile.Name;
      var nameWithoutExtention = oldName.Substring(0, oldName.Length - inputFile.Extension.Length);
      var newName = String.Concat(nameWithoutExtention, CssExtension);
      return Path.Combine(outputDirectory.FullName, newName);
    }

    public SassCompiler(ISassConverter converter = null)
    {
      this.converter = converter?? new SharpScssConverter();
    }
  }
}
