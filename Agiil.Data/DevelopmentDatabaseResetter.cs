using System;
using Agiil.Domain.Data;
using NHibernate;

namespace Agiil.Data
{
  public class DevelopmentDatabaseResetter : IResetsDatabase
  {
    readonly ICreatesDatabaseSchema dbCreator;
    readonly IInitialDataCreator dataCreator;
    readonly IDeletesDatabase databaseDeleter;

    public void ResetDatabase()
    {
      databaseDeleter.DeleteDatabase();
      dbCreator.CreateSchema();
      dataCreator.Create();
    }

    public DevelopmentDatabaseResetter(IDeletesDatabase databaseDeleter,
                                       ICreatesDatabaseSchema dbCreator,
                                       IInitialDataCreator dataCreator)
    {
      if(databaseDeleter == null)
        throw new ArgumentNullException(nameof(databaseDeleter));
      if(dataCreator == null)
        throw new ArgumentNullException(nameof(dataCreator));
      if(dbCreator == null)
        throw new ArgumentNullException(nameof(dbCreator));

      this.dbCreator = dbCreator;
      this.dataCreator = dataCreator;
      this.databaseDeleter = databaseDeleter;
    }
  }
}
