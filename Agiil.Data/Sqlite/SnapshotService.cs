using System;
using System.IO;
using log4net;

namespace Agiil.Data.Sqlite
{
    public class SnapshotService : ISnapshotService
    {
        readonly DatabaseFileProvider dbFileProvider;
        readonly ISnapshotFileService fileService;
        readonly ILog logger;

        public void RestoreFromSnapshot(Snapshot snapshot)
        {
            if(snapshot == null)
                throw new ArgumentNullException(nameof(snapshot));

            var dataFile = dbFileProvider.GetDatabaseFile();
            fileService.Replace(snapshot.File, dataFile);

            logger.Debug($"Restored database {dataFile.Name} using {snapshot.File.Name}");
        }

        public Snapshot TakeDatabaseSnapshot()
        {
            var dataFile = dbFileProvider.GetDatabaseFile();
            logger.Debug($"{nameof(TakeDatabaseSnapshot)} getting the file for a new snapshot, based on data file '{dataFile.FullName}'");
            var snapshotFile = fileService.GetFileForNewSnapshot(dataFile);
            logger.Debug($"{nameof(TakeDatabaseSnapshot)} got new snapshot file: '{snapshotFile.FullName}'");
            fileService.Copy(dataFile, snapshotFile);
            return GetSnapshot(snapshotFile);
        }

        Snapshot GetSnapshot(FileInfo file) => new Snapshot(file);

        object ISnapshotService.TakeDatabaseSnapshot() => TakeDatabaseSnapshot();

        void ISnapshotService.RestoreFromSnapshot(object snapshot)
        {
            RestoreFromSnapshot((Snapshot) snapshot);
        }

        public SnapshotService(DatabaseFileProvider dbFileProvider,
                               ISnapshotFileService fileService,
                               ILog logger)
        {
            if(dbFileProvider == null)
                throw new ArgumentNullException(nameof(dbFileProvider));
            if(fileService == null)
                throw new ArgumentNullException(nameof(fileService));

            this.fileService = fileService;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.dbFileProvider = dbFileProvider;
        }
    }
}
