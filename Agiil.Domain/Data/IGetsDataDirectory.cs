using System;
using System.IO;

namespace Agiil.Domain.Data
{
  public interface IGetsDataDirectory
  {
    DirectoryInfo GetDataDirectory();
  }
}
