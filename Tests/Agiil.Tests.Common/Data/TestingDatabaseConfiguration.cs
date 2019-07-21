using System;
using Agiil.Data;

namespace Agiil.Tests.Data
{
  public class TestingDatabaseConfiguration : IDatabaseConfiguration
  {
    const string ConnectionStringName = "Agiil_Testing";

    public virtual string GetConnectionStringName() => ConnectionStringName;
  }
}
