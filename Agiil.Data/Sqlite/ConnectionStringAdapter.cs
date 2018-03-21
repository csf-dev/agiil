using System;
using System.Text.RegularExpressions;

namespace Agiil.Data.Sqlite
{
  public class ConnectionStringAdapter
  {
    const string DataFilePattern = @"Data Source=([^;]+)";
    static readonly Regex DataFileMatcher = new Regex(DataFilePattern,
                                                      RegexOptions.CultureInvariant
                                                      | RegexOptions.IgnoreCase
                                                      | RegexOptions.Compiled);

    readonly string connectionString;

    public string ConnectionString => connectionString;

    public string GetDataFile()
    {
      var match = DataFileMatcher.Match(ConnectionString);

      if(!match.Success)
        return null;

      return match.Groups[1].Value;
    }

    public ConnectionStringAdapter(string connectionString)
    {
      if(connectionString == null)
        throw new ArgumentNullException(nameof(connectionString));

      this.connectionString = connectionString;
    }
  }
}
