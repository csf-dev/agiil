using System;
using System.IO;
using Agiil.Domain;
using Agiil.Domain.Data;

namespace Agiil.Data.Sqlite
{
  public class BackupFileInfoProvider : IProvidesBackupFileInfo
  {
    readonly IFormatsDatabaseBackupFilenames backupFilenameFormatter;
    readonly IGetsDataDirectory dataDirectoryProvider;
    readonly IProvidesVersionInformation versionProvider;
    readonly IEnvironment environment;

    public virtual FileInfo GetBackupFileFromBackupName(string name)
    {
      var backupInfo = GetBackupInfo(name);
      var backupFilename = backupFilenameFormatter.GetFilename(backupInfo);
      return GetBackupFileFromFilename(backupFilename);
    }

    public virtual FileInfo GetBackupFileFromFilename(string filename)
    {
      var backupFilePath = Path.Combine(dataDirectoryProvider.GetDataDirectory().FullName, filename);
      return new FileInfo(backupFilePath);
    }

    DatabaseBackupInfo GetBackupInfo(string name)
    {
      var backupName = String.IsNullOrEmpty(name)? null : name;

      return new DatabaseBackupInfo {
        ApplicationVersion = versionProvider.GetHumanReadableProductVersion(),
        Timestamp = environment.GetCurrentUtcTimestamp(),
        Name = backupName
      };
    }

    public BackupFileInfoProvider(IFormatsDatabaseBackupFilenames backupFilenameFormatter,
                                  IGetsDataDirectory dataDirectoryProvider,
                                  IProvidesVersionInformation versionProvider,
                                  IEnvironment environment)
    {
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      if(versionProvider == null)
        throw new ArgumentNullException(nameof(versionProvider));
      if(dataDirectoryProvider == null)
        throw new ArgumentNullException(nameof(dataDirectoryProvider));
      if(backupFilenameFormatter == null)
        throw new ArgumentNullException(nameof(backupFilenameFormatter));

      this.environment = environment;
      this.versionProvider = versionProvider;
      this.dataDirectoryProvider = dataDirectoryProvider;
      this.backupFilenameFormatter = backupFilenameFormatter;
    }
  }
}
