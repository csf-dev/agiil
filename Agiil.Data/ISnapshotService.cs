using System;
namespace Agiil.Data
{
  public interface ISnapshotService
  {
    object TakeDatabaseSnapshot();

    void RestoreFromSnapshot(object snapshot);
  }
}
