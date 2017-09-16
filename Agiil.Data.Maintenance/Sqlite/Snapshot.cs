using System;
using System.IO;

namespace Agiil.Data.Maintenance.Sqlite
{
  public class Snapshot
  {
    readonly FileInfo snapshotFile;
    public virtual FileInfo File => snapshotFile;

    public Snapshot(FileInfo snapshotFile)
    {
      if(snapshotFile == null)
        throw new ArgumentNullException(nameof(snapshotFile));

      this.snapshotFile = snapshotFile;
    }
  }
}
