using System;
using System.IO;

namespace Agiil.Data.Maintenance
{
  public interface IExportsDatabaseSchema
  {
    void ExportToFile(string outputFile);

    string Export();

    void Export(TextWriter writer);
  }
}
