using System;
namespace Agiil.Domain.Data
{
  public interface ITakesDatabaseBackup
  {
    void TakeDatabaseBackup(string name);
  }
}
