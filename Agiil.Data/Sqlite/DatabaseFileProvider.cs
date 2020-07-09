using System;
using System.IO;

namespace Agiil.Data.Sqlite
{
  public class DatabaseFileProvider
  {
    readonly IGetsDatabaseFilePath connectionStringAdapter;

    public FileInfo GetDatabaseFile()
    {
      var filePath = connectionStringAdapter.GetDataFile();
      return new FileInfo(filePath);
    }

    public DatabaseFileProvider(Func<IConnectionStringProvider, IGetsDatabaseFilePath> connectionStringAdapterFactory,
                                IConnectionStringProvider connectionStringProvider)
    {
      connectionStringAdapter = connectionStringAdapterFactory(connectionStringProvider);
    }
  }
}
