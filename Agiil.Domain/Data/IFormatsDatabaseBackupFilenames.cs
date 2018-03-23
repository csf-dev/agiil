using System;
namespace Agiil.Domain.Data
{
  public interface IFormatsDatabaseBackupFilenames
  {
    string GetFilename(DatabaseBackupInfo backupInfo);

    bool IsValidFilename(string filename);

    DatabaseBackupInfo GetBackupInfo(string filename);
  }
}
