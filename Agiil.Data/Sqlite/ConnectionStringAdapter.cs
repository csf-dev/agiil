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

        public string ConnectionString { get; }

        public string GetDataFile()
        {
            var match = DataFileMatcher.Match(ConnectionString);
            Console.WriteLine(ConnectionString);

            return match.Success ? match.Groups[1].Value : null;
        }

        public ConnectionStringAdapter(string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public static ConnectionStringAdapter Create(IConnectionStringProvider connectionStringProvider)
        {
            if(connectionStringProvider == null)
                throw new ArgumentNullException(nameof(connectionStringProvider));

            var connString = connectionStringProvider.GetConnectionString();
            return new ConnectionStringAdapter(connString);
        }
    }
}
