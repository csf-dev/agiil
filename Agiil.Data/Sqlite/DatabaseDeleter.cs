using System;
using System.IO;

namespace Agiil.Data.Sqlite
{
    public class DatabaseDeleter : IDeletesDatabase
    {
        readonly ConnectionStringAdapter connectionStringAdapter;

        public void DeleteDatabase()
        {
            Console.WriteLine("Deleting the database ...");
            File.Delete(connectionStringAdapter.GetDataFile());
        }

        public DatabaseDeleter(IConnectionStringProvider connectionStringProvider)
        {
            connectionStringAdapter = ConnectionStringAdapter.Create(connectionStringProvider);
        }
    }
}
