using System;

namespace Agiil.Domain.Data
{
  public class DatabaseBackupInfo
  {
    public string Filename { get; set; }

    public DateTime Timestamp { get; set; }

    public string Name { get; set; }

    public string ApplicationVersion { get; set; }
  }
}
