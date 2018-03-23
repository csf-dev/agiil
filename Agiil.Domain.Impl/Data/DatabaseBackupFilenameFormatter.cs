using System;
using System.Text.RegularExpressions;

namespace Agiil.Domain.Data
{
  public class DatabaseBackupFilenameFormatter : IFormatsDatabaseBackupFilenames
  {
    const string DatabaseBackupFilePattern = @"^(\d{4})-(\d{2})-(\d{2})T(\d{2})(\d{2})(\d{2})Z_([^_]+)(?:_(.+))?.sqlite.backup$";
    static readonly Regex DatabaseBackupFileMatcher = new Regex(DatabaseBackupFilePattern,
                                                                RegexOptions.CultureInvariant | RegexOptions.Compiled);

    public DatabaseBackupInfo GetBackupInfo(string filename)
    {
      if(filename == null) return null;
      var match = DatabaseBackupFileMatcher.Match(filename);
      if(!match.Success) return null;

      var timestamp = ParseTimestamp(match);
      if(timestamp == null) return null;

      var name = match.Groups?[8]?.Value;

      return new DatabaseBackupInfo {
        Timestamp = timestamp.Value,
        ApplicationVersion = match.Groups[7].Value,
        Name = String.IsNullOrEmpty(name)? null : name,
      };
    }

    DateTime? ParseTimestamp(Match match)
    {
      try
      {
        return new DateTime(Int32.Parse(match.Groups[1].Value),
                            Int32.Parse(match.Groups[2].Value),
                            Int32.Parse(match.Groups[3].Value),
                            Int32.Parse(match.Groups[4].Value),
                            Int32.Parse(match.Groups[5].Value),
                            Int32.Parse(match.Groups[6].Value),
                            DateTimeKind.Utc);
      }
      catch(Exception) { return null; }
    }

    public string GetFilename(DatabaseBackupInfo backupInfo)
    {
      if(backupInfo == null) return null;
      if(String.IsNullOrEmpty(backupInfo.ApplicationVersion)) return null;

      var timeString = backupInfo.Timestamp.ToUniversalTime().ToString("yyyy-MM-ddTHHmmssK");
      var output = $"{timeString}_{backupInfo.ApplicationVersion}";

      if(!String.IsNullOrEmpty(backupInfo.Name))
        output = $"{output}_{backupInfo.Name}";

      return $"{output}.sqlite.backup";
    }

    public bool IsValidFilename(string filename) => GetBackupInfo(filename) != null;
  }
}
