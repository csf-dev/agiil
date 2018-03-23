using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Agiil.Domain.Data
{
  public class DatabaseBackupFinder : IGetsDatabaseBackups
  {
    readonly IGetsDataDirectory dataDirectoryProvider;
    readonly IFormatsDatabaseBackupFilenames filenameFormatter;

    public IReadOnlyList<DatabaseBackupInfo> GetBackups()
    {
      var baseDirectory = dataDirectoryProvider.GetDataDirectory();
      return GetBackups(baseDirectory);
    }

    public IReadOnlyList<DatabaseBackupInfo> GetBackups(DirectoryInfo baseDirectory)
      => baseDirectory.GetFiles().Select(GetBackupInfo).Where(x => x != null).OrderBy(x => x.Timestamp).ToArray();

    DatabaseBackupInfo GetBackupInfo(FileInfo file) => filenameFormatter.GetBackupInfo(file?.Name);

    public DatabaseBackupFinder(IGetsDataDirectory dataDirectoryProvider,
                                IFormatsDatabaseBackupFilenames filenameFormatter)
    {
      if(filenameFormatter == null)
        throw new ArgumentNullException(nameof(filenameFormatter));
      if(dataDirectoryProvider == null)
        throw new ArgumentNullException(nameof(dataDirectoryProvider));
      
      this.filenameFormatter = filenameFormatter;
      this.dataDirectoryProvider = dataDirectoryProvider;
    }
  }
}
