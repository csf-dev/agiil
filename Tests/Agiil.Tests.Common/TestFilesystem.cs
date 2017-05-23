using System;
using System.Configuration;
using System.IO;

namespace Agiil.Tests
{
  public static class TestFilesystem
  {
    const string TempPathAppSettingsKey = "TestTempPath";

    public static DirectoryInfo GetTestTemporaryDirectory()
    {
      var pathString = ConfigurationManager.AppSettings[TempPathAppSettingsKey];

      if(pathString == null)
        return null;

      var dir = new DirectoryInfo(pathString);
      if(!dir.Exists)
        return null;

      return dir;
    }

    public static DirectoryInfo GetTestTemporaryDirectory<T>()
    {
      var baseDir = GetTestTemporaryDirectory();
      if(baseDir == null)
        return null;

      var subDir = new DirectoryInfo(Path.Combine(baseDir.FullName, typeof(T).FullName));
      if(!subDir.Exists)
        subDir.Create();

      return subDir;
    }
  }
}
