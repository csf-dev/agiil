using System;
using System.IO;

namespace Agiil.Data.Maintenance
{
  public interface IDbSchemaExporter
  {
    string Export();

    void Export(TextWriter writer);

    void Export(string filePath);
  }
}
