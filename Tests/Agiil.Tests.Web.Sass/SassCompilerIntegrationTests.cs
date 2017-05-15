using System;
using System.IO;
using Agiil.Web.Sass;
using NUnit.Framework;

namespace Agiil.Tests.Web.Sass
{
  [TestFixture]
  #if !DEBUG
  [Ignore("The tests in this fixture expect the output from a DEBUG build, they would fail outside of such a build.")]
  #endif
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

      var expected = @"/* line 2, Tests/Temp/Agiil.Tests.Web.Sass.SassCompilerIntegrationTests/_two.scss */
p {
  background: blue;
}

/* line 4, Tests/Temp/Agiil.Tests.Web.Sass.SassCompilerIntegrationTests/one.scss */
nav {
  background: red;
}

/* line 7, Tests/Temp/Agiil.Tests.Web.Sass.SassCompilerIntegrationTests/one.scss */
nav ul {
  background: yellow;
}

/*# sourceMappingURL=one.css.map */
";

      // Act
      sut.Compile(options);

      // Assert
      var result = ReadOutputFile("one.css", testDirectory);
      Assert.AreEqual(expected, result);
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

    string ReadOutputFile(string filename, DirectoryInfo outputDirectory)
    {
      var filePath = Path.Combine(outputDirectory.FullName, filename);
      if(!File.Exists(filePath))
        return null;
      return File.ReadAllText(filePath);
    }
  }
}
