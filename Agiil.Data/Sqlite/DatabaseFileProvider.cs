using System;
using System.IO;

namespace Agiil.Data.Sqlite
{
  public class DatabaseFileProvider
  {
    readonly ConnectionStringAdapter connectionStringAdapter;

    public FileInfo GetDatabaseFile()
    {
      var filePath = connectionStringAdapter.GetDataFile();
      return new FileInfo(filePath);
    }

    public DatabaseFileProvider(IConnectionStringProvider connectionStringProvider)
    {
      connectionStringAdapter = ConnectionStringAdapter.Create(connectionStringProvider);
    }
  }
}
