using System;
using System.IO;
using Agiil.Web.Sass;
using NUnit.Framework;

namespace Agiil.Tests.Web.Sass
{
  [TestFixture]
  public class SassCompilerIntegrationTests
  {
    [Test]
    public void Compile_compiles_a_scss_file_to_output_file()
    {
      // Arrange
      var sut = GetSut();
      var testDirectory = GetTestDirectory();
      CreateSampleScssFilesWithImport(testDirectory);
      testDirectory.Refresh();
      var options = new SassCompilationOptions
      {
        SourceDirectory = testDirectory,
        OutputDirectory = testDirectory
      };

      // Act
      sut.Compile(options);

      // Assert
    }

    ISassCompiler GetSut()
    {
      return new SassCompiler();
    }

    void CreateSampleScssFilesWithImport(DirectoryInfo testDirectory)
    {
      var fileOne = @"
@import '_two';

nav {
  background: red;

  ul {
    background: yellow;
  }
}";
      var fileTwo = @"
p {
  background: blue;
}";
      using(var writer = File.CreateText(Path.Combine(testDirectory.FullName, "one.scss")))
      {
        writer.WriteLine(fileOne);
      }
      using(var writer = File.CreateText(Path.Combine(testDirectory.FullName, "_two.scss")))
      {
        writer.WriteLine(fileTwo);
      }
    }

    DirectoryInfo GetTestDirectory()
    {
      var output = TestFilesystem.GetTestTemporaryDirectory<SassCompilerIntegrationTests>();
      if(output == null)
        output = new DirectoryInfo(Environment.CurrentDirectory);

      return output;
    }
  }
}
