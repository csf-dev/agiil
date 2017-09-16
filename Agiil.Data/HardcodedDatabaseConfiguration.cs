using System;
namespace Agiil.Data
{
  public class HardcodedDatabaseConfiguration : IDatabaseConfiguration
  {
    const string ConnectionStringName = "Agiil";

    public virtual string GetConnectionStringName() => ConnectionStringName;
  }
}
