using System;
using System.IO;
using Agiil.Domain;
using CSF.IO;

namespace Agiil.Data.Maintenance.Sqlite
{
  public class SnapshotFileService : ISnapshotFileService
  {
    readonly IEnvironment environment;
    readonly ExtensionChanger extensionChanger;

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
      var filename = GetSnapshotFilename(existingFile.Name);

      return new FileInfo(Path.Combine(parentDirectory.FullName, filename));
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

    public SnapshotFileService(IEnvironment environment, ExtensionChanger extensionChanger)
    {
      if(extensionChanger == null)
        throw new ArgumentNullException(nameof(extensionChanger));
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));

      this.environment = environment;
      this.extensionChanger = extensionChanger;
    }
  }
}
