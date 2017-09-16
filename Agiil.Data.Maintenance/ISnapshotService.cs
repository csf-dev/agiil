using System;
namespace Agiil.Data.Maintenance
{
  public interface ISnapshotService
  {
    object TakeDatabaseSnapshot();

    void RestoreFromSnapshot(object snapshot);
  }
}
