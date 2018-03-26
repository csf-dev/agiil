using System.IO;

namespace Agiil.Data.Sqlite
{
  public interface IProvidesBackupFileInfo
  {
    FileInfo GetBackupFileFromBackupName(string name);

    FileInfo GetBackupFileFromFilename(string filename);
  }
}