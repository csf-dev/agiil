using System;
using Agiil.Domain.Data;

namespace Agiil.Data.Sqlite
{
  public class SqliteBackupRestorer : IRestoresDatabaseBackup
  {
    readonly IProvidesBackupFileInfo backupFileProvider;
    readonly DatabaseFileProvider fileProvider;
    readonly ISnapshotFileService fileService;

    public void RestoreDatabaseBackup(string backupFilenameToRestore)
    {
      var backupFile = backupFileProvider.GetBackupFileFromFilename(backupFilenameToRestore);
      var dbFile = fileProvider.GetDatabaseFile();

      fileService.Replace(backupFile, dbFile);
    }

    public SqliteBackupRestorer(IProvidesBackupFileInfo backupFileProvider,
                                DatabaseFileProvider fileProvider,
                                ISnapshotFileService fileService)
    {
      if(fileService == null)
        throw new ArgumentNullException(nameof(fileService));
      if(fileProvider == null)
        throw new ArgumentNullException(nameof(fileProvider));
      if(backupFileProvider == null)
        throw new ArgumentNullException(nameof(backupFileProvider));

      this.backupFileProvider = backupFileProvider;
      this.fileProvider = fileProvider;
      this.fileService = fileService;
    }
  }
}
