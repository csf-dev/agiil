using System;
using System.Text.RegularExpressions;
using log4net;

namespace Agiil.Data.Sqlite
{
    public class ConnectionStringAdapter : IGetsDatabaseFilePath
    {
        const string DataFilePattern = @"Data Source=([^;]+)";
        static readonly Regex DataFileMatcher = new Regex(DataFilePattern,
                                                          RegexOptions.CultureInvariant
                                                          | RegexOptions.IgnoreCase
                                                          | RegexOptions.Compiled);
        readonly ILog logger;

        public string ConnectionString { get; }

        public string GetDataFile()
        {
            var match = DataFileMatcher.Match(ConnectionString);
            logger.Debug(ConnectionString);

            return match.Success ? match.Groups[1].Value : null;
        }

        public ConnectionStringAdapter(string connectionString, ILog logger)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
