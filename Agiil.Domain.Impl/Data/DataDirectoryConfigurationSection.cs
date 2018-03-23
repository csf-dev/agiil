using System;
using System.Configuration;
using System.IO;
using CSF.Configuration;

namespace Agiil.Domain.Data
{
  [ConfigurationPath("Agiil/DataDirectory")]
  public class DataDirectoryConfigurationSection : ConfigurationSection, IGetsDataDirectory
  {
    const string RootDirectoryConfigName = @"RootDirectory";
    [ConfigurationProperty(RootDirectoryConfigName, IsRequired = true)]
    public virtual string RootDirectory
    {
      get { return (string) this[RootDirectoryConfigName]; }
      set { this[RootDirectoryConfigName] = value; }
    }

    public DirectoryInfo GetDataDirectory() => new DirectoryInfo(RootDirectory);
  }
}