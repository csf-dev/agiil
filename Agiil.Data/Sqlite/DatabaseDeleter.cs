using System;
using System.IO;
using log4net;

namespace Agiil.Data.Sqlite
{
    public class DatabaseDeleter : IDeletesDatabase
    {
        readonly IGetsDatabaseFilePath connectionStringAdapter;
        private readonly ILog logger;

        public void DeleteDatabase()
        {
            var dataFile = connectionStringAdapter.GetDataFile();
            logger.Debug($"Deleting the database at {dataFile}");
            File.Delete(dataFile);
        }

        public DatabaseDeleter(Func<IConnectionStringProvider, IGetsDatabaseFilePath> connectionStringAdapterFactory,
                               IConnectionStringProvider connectionStringProvider,
                               ILog logger)
        {
            if(connectionStringAdapterFactory == null)
                throw new ArgumentNullException(nameof(connectionStringAdapterFactory));
            if(connectionStringProvider == null)
                throw new ArgumentNullException(nameof(connectionStringProvider));

            connectionStringAdapter = connectionStringAdapterFactory(connectionStringProvider);
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
