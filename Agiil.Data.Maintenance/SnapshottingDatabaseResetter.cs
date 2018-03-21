using System;
using Agiil.Domain.Data;

namespace Agiil.Data.Maintenance
{
  public class SnapshottingDatabaseResetter : IResetsDatabase
  {
    static readonly object syncRoot;

    readonly IResetsDatabase baseResetter;
    readonly SnapshotStore snapshotStore;
    readonly ISnapshotService snapshotService;

    public void ResetDatabase()
    {
      lock(syncRoot)
      {
        if(snapshotStore.CurrentSnapshot == null)
        {
          var snapshot = PerformFullResetAndTakeSnapshot();
          snapshotStore.CurrentSnapshot = snapshot;
        }
        else
        {
          snapshotService.RestoreFromSnapshot(snapshotStore.CurrentSnapshot);
        }
      }
    }

    object PerformFullResetAndTakeSnapshot()
    {
      baseResetter.ResetDatabase();
      return snapshotService.TakeDatabaseSnapshot();
    }

    public SnapshottingDatabaseResetter(IResetsDatabase baseResetter,
                                        SnapshotStore snapshotStore,
                                        ISnapshotService snapshotService)
    {
      if(snapshotService == null)
        throw new ArgumentNullException(nameof(snapshotService));
      if(snapshotStore == null)
        throw new ArgumentNullException(nameof(snapshotStore));
      if(baseResetter == null)
        throw new ArgumentNullException(nameof(baseResetter));
      
      this.snapshotService = snapshotService;
      this.snapshotStore = snapshotStore;
      this.baseResetter = baseResetter;
    }

    static SnapshottingDatabaseResetter()
    {
      syncRoot = new object();
    }
  }
}
