using System;
namespace Agiil.Data.Maintenance
{
  public class SnapshottingDatabaseResetter : IDatabaseResetter
  {
    static readonly object syncRoot;

    readonly IDatabaseResetter baseResetter;
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

    public SnapshottingDatabaseResetter(IDatabaseResetter baseResetter,
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
