using System;
using Agiil.Domain.Data;

namespace Agiil.Data.Sqlite
{
  public class SqliteBackupCreator : ITakesDatabaseBackup
  {
    readonly IProvidesBackupFileInfo backupFileProvider;
    readonly ISnapshotFileService snapshotFileService;
    readonly DatabaseFileProvider dbFileProvider;

    public void TakeDatabaseBackup(string name)
    {
      var backupFile = backupFileProvider.GetBackupFile(name);
      var dbFile = dbFileProvider.GetDatabaseFile();
      snapshotFileService.Copy(dbFile, backupFile);
    }

    public SqliteBackupCreator(IProvidesBackupFileInfo backupFileProvider,
                               ISnapshotFileService snapshotFileService,
                               DatabaseFileProvider dbFileProvider)
    {
      if(dbFileProvider == null)
        throw new ArgumentNullException(nameof(dbFileProvider));
      if(backupFileProvider == null)
        throw new ArgumentNullException(nameof(backupFileProvider));
      if(snapshotFileService == null)
        throw new ArgumentNullException(nameof(snapshotFileService));
      
      this.dbFileProvider = dbFileProvider;
      this.backupFileProvider = backupFileProvider;
      this.snapshotFileService = snapshotFileService;
    }
  }
}
