using System;
using System.IO;
using Agiil.Web.Sass;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Agiil.Build.Tasks
{
  public class CompileScssFiles : Task
  {
    [Required]
    public string SourcePath { get; set; }

    [Required]
    public string DestinationPath { get; set; }

    public override bool Execute()
    {
      var compiler = new SassCompiler();

      var options = new SassCompilationOptions
      {
        SourceDirectory = new DirectoryInfo(SourcePath),
        OutputDirectory = new DirectoryInfo(DestinationPath),
      };

      compiler.Compile(options);

      return true;
    }
  }
}
