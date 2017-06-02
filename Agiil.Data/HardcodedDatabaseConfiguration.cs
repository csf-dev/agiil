using System;
namespace Agiil.Data
{
  public class HardcodedDatabaseConfiguration : IDatabaseConfiguration
  {
    const string ConnectionStringName = "Agiil";

    public string GetConnectionStringName() => ConnectionStringName;
  }
}
