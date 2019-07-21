using System;
using System.IO;
using Agiil.Domain;
using CSF.IO;
using log4net;

namespace Agiil.Data.Sqlite
{
  public class SnapshotFileService : ISnapshotFileService
  {
    readonly IEnvironment environment;
    readonly ExtensionChanger extensionChanger;
    private readonly ILog logger;

    public void Replace(FileInfo source, FileInfo destination)
    {
      if(source == null)
        throw new ArgumentNullException(nameof(source));
      if(destination == null)
        throw new ArgumentNullException(nameof(destination));
      
      EnsureExists(source, "The source snapshot file");
      EnsureExists(destination, "The destination database file");

      File.Copy(source.FullName, destination.FullName, true);
    }

    public void Copy(FileInfo source, FileInfo destination)
    {
      if(source == null)
        throw new ArgumentNullException(nameof(source));
      if(destination == null)
        throw new ArgumentNullException(nameof(destination));

      EnsureExists(source, "The SQLite database file");

      File.Copy(source.FullName, destination.FullName, false);

      destination.Refresh();
    }

    public FileInfo GetFileForNewSnapshot(FileInfo existingFile)
    {
      if(existingFile == null)
        throw new ArgumentNullException(nameof(existingFile));
      
      EnsureExists(existingFile, "The SQLite database file");

      var parentDirectory = existingFile.GetParentDirectory();
      logger.Debug($"{nameof(GetFileForNewSnapshot)} parent directory is '{parentDirectory.FullName}'");
      var filename = GetSnapshotFilename(existingFile.Name);
      logger.Debug($"{nameof(GetFileForNewSnapshot)} snapshot filename to be '{filename}'");

      var snapshotPath = Path.Combine(parentDirectory.FullName, filename);
      logger.Debug($"{nameof(GetFileForNewSnapshot)} snapshow path to be '{snapshotPath}'");

      return new FileInfo(snapshotPath);
    }

    string GetSnapshotFilename(string baseFilename)
    {
      var timestamp = environment.GetCurrentLocalTimestamp().ToString("s");
      var newExtension = $"snapshot.{timestamp}";
      var newFilename = extensionChanger.InsertExtensionBeforeLast(baseFilename, newExtension);

      return newFilename;
    }

    void EnsureExists(FileInfo file, string name = "The database file")
    {
      if(file == null)
        throw new ArgumentNullException(nameof(file));

      if(!file.Exists)
        throw new FileNotFoundException($"{name} must exist", file.FullName);
    }

    public SnapshotFileService(IEnvironment environment,
                               ExtensionChanger extensionChanger,
                               ILog logger)
    {
      if(extensionChanger == null)
        throw new ArgumentNullException(nameof(extensionChanger));
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));

      this.environment = environment;
      this.extensionChanger = extensionChanger;
      this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
  }
}
