using System.Collections.Generic;

namespace Agiil.Domain.Data
{
  public interface IGetsDatabaseBackups
  {
    IReadOnlyList<DatabaseBackupInfo> GetBackups();
  }
}
