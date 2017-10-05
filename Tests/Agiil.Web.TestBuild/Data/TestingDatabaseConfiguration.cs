using System;
using Agiil.Data;

namespace Agiil.Web.Data
{
  public class TestingDatabaseConfiguration : IDatabaseConfiguration
  {
    const string ConnectionStringName = "Agiil_Testing";

    public virtual string GetConnectionStringName() => ConnectionStringName;
  }
}
