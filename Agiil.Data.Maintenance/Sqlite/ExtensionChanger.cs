using System;
using System.Text.RegularExpressions;

namespace Agiil.Data.Maintenance.Sqlite
{
  public class ExtensionChanger
  {
    const string LastExtensionPattern = @"[^.]+$";
    readonly static Regex LastExtensionMatcher = new Regex(LastExtensionPattern, RegexOptions.Compiled);

    public string InsertExtensionBeforeLast(string filename, string extensionToAdd)
    {
      if(filename == null)
        throw new ArgumentNullException(nameof(filename));
      if(extensionToAdd == null)
        throw new ArgumentNullException(nameof(extensionToAdd));

      return LastExtensionMatcher.Replace(filename, match => $".{extensionToAdd}.{match.Value}");
    }

    public string AppendExtension(string filename, string extensionToAdd)
    {
      if(filename == null)
        throw new ArgumentNullException(nameof(filename));
      if(extensionToAdd == null)
        throw new ArgumentNullException(nameof(extensionToAdd));

      return $"{filename}.{extensionToAdd}";
    }
  }
}
