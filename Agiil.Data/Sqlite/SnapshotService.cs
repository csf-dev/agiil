using System;
using System.IO;

namespace Agiil.Data.Sqlite
{
  public class SnapshotService : ISnapshotService
  {
    readonly DatabaseFileProvider dbFileProvider;
    readonly ISnapshotFileService fileService;

    public void RestoreFromSnapshot(Snapshot snapshot)
    {
      if(snapshot == null)
        throw new ArgumentNullException(nameof(snapshot));
      
      var dataFile = dbFileProvider.GetDatabaseFile();
      fileService.Replace(snapshot.File, dataFile);
    }

    public Snapshot TakeDatabaseSnapshot()
    {
      var dataFile = dbFileProvider.GetDatabaseFile();
      var snapshotFile = fileService.GetFileForNewSnapshot(dataFile);
      fileService.Copy(dataFile, snapshotFile);
      return GetSnapshot(snapshotFile);
    }

    Snapshot GetSnapshot(FileInfo file) => new Snapshot(file);

    object ISnapshotService.TakeDatabaseSnapshot() => TakeDatabaseSnapshot();

    void ISnapshotService.RestoreFromSnapshot(object snapshot)
    {
      RestoreFromSnapshot((Snapshot) snapshot);
    }

    public SnapshotService(DatabaseFileProvider dbFileProvider,
                           ISnapshotFileService fileService)
    {
      if(dbFileProvider == null)
        throw new ArgumentNullException(nameof(dbFileProvider));
      if(fileService == null)
        throw new ArgumentNullException(nameof(fileService));
      
      this.fileService = fileService;
      this.dbFileProvider = dbFileProvider;
    }
  }
}
