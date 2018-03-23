using System.IO;

namespace Agiil.Data.Sqlite
{
  public interface IProvidesBackupFileInfo
  {
    FileInfo GetBackupFile(string name);
  }
}