using System;
using System.IO;

namespace Agiil.Tests
{
  public static class TestingEnvironment
  {
    const string ArtifactsDirectory = "test-artifacts";

    public static DirectoryInfo GetArtifactsDirectory()
    {
      var artifactsDir = new DirectoryInfo(TestingEnvironment.ArtifactsDirectory);
      if(!artifactsDir.Exists)
      {
        artifactsDir.Create();
        artifactsDir.Refresh();
      }

      return artifactsDir;
    }
  }
}
