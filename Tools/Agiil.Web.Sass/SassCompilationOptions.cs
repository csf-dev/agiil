using System;
using System.IO;

namespace Agiil.Web.Sass
{
  public class SassCompilationOptions
  {
    internal const string IgnorePrefix = "_";

    public DirectoryInfo SourceDirectory { get; set; }

    public DirectoryInfo OutputDirectory { get; set; }

    public Func<string,bool> FileMatcher { get; set; } = DoesNotStartWithIgnoredPrefix;

    static bool DoesNotStartWithIgnoredPrefix(string filename)
    {
      return !filename.StartsWith(IgnorePrefix, StringComparison.InvariantCultureIgnoreCase);
    }
  }
}
