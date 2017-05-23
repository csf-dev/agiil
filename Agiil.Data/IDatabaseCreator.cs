using System;
using System.Data;
using System.IO;
using NHibernate.Cfg;

namespace Agiil.Data
{
  public interface IDatabaseCreator
  {
    void Create(IDbConnection connection, TextWriter outputWriter);

    void Create(string outputFile, bool execute);

    void Create(string outputFile);

    void Create();
  }
}
