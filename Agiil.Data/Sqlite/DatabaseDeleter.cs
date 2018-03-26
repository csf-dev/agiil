using System;
using System.IO;

namespace Agiil.Data.Sqlite
{
  public class DatabaseDeleter : IDeletesDatabase
  {
    readonly ConnectionStringAdapter connectionStringAdapter;

    public void DeleteDatabase() => File.Delete(connectionStringAdapter.GetDataFile());

    public DatabaseDeleter(IConnectionStringProvider connectionStringProvider)
    {
      connectionStringAdapter = ConnectionStringAdapter.Create(connectionStringProvider);
    }
  }
}
