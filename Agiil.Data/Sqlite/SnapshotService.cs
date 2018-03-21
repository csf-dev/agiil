using System;
using System.IO;

namespace Agiil.Data.Sqlite
{
  public class SnapshotService : ISnapshotService
  {
    readonly ConnectionStringAdapter connectionStringAdapter;
    readonly ISnapshotFileService fileService;

    public void RestoreFromSnapshot(Snapshot snapshot)
    {
      if(snapshot == null)
        throw new ArgumentNullException(nameof(snapshot));
      
      var dataFile = GetDatabaseFile();
      fileService.Replace(snapshot.File, dataFile);
    }

    public Snapshot TakeDatabaseSnapshot()
    {
      var dataFile = GetDatabaseFile();
      var snapshotFile = fileService.GetFileForNewSnapshot(dataFile);
      fileService.Copy(dataFile, snapshotFile);
      return GetSnapshot(snapshotFile);
    }

    FileInfo GetDatabaseFile()
    {
      var filePath = connectionStringAdapter.GetDataFile();
      return new FileInfo(filePath);
    }

    Snapshot GetSnapshot(FileInfo file) => new Snapshot(file);

    object ISnapshotService.TakeDatabaseSnapshot() => TakeDatabaseSnapshot();

    void ISnapshotService.RestoreFromSnapshot(object snapshot)
    {
      RestoreFromSnapshot((Snapshot) snapshot);
    }

    public SnapshotService(IConnectionStringProvider connectionStringProvider,
                           ISnapshotFileService fileService)
    {
      if(fileService == null)
        throw new ArgumentNullException(nameof(fileService));
      
      this.fileService = fileService;
      connectionStringAdapter = ConnectionStringAdapter.Create(connectionStringProvider);
    }
  }
}
