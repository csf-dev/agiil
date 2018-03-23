using System;
namespace Agiil.Domain.Data
{
  public interface IRestoresDatabaseBackup
  {
    void RestoreDatabaseBackup(string backupFilenameToRestore);
  }
}
