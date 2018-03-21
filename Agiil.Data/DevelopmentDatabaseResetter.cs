using System;
using Agiil.Domain.Data;
using NHibernate;

namespace Agiil.Data
{
  public class DevelopmentDatabaseResetter : IResetsDatabase
  {
    readonly ICreatesDatabaseSchema dbCreator;
    readonly IInitialDataCreator dataCreator;

    public void ResetDatabase()
    {
      dbCreator.CreateSchema();
      dataCreator.Create();
    }

    public DevelopmentDatabaseResetter(ICreatesDatabaseSchema dbCreator,
                                       IInitialDataCreator dataCreator)
    {
      if(dataCreator == null)
        throw new ArgumentNullException(nameof(dataCreator));
      if(dbCreator == null)
        throw new ArgumentNullException(nameof(dbCreator));

      this.dbCreator = dbCreator;
      this.dataCreator = dataCreator;
    }
  }
}
