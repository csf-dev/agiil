using System;
using Agiil.Domain.Data;
using NHibernate;

namespace Agiil.Data.Maintenance
{
  public class DevelopmentDatabaseResetter : IResetsDatabase
  {
    readonly ISession session;
    readonly ICreatesDatabaseSchema dbCreator;
    readonly IInitialDataCreator dataCreator;

    public void ResetDatabase()
    {
      var connection = session.Connection;
      dbCreator.CreateSchema(connection);
      dataCreator.Create();
    }

    public DevelopmentDatabaseResetter(ISession session,
                                       ICreatesDatabaseSchema dbCreator,
                                       IInitialDataCreator dataCreator)
    {
      if(dataCreator == null)
        throw new ArgumentNullException(nameof(dataCreator));
      if(dbCreator == null)
        throw new ArgumentNullException(nameof(dbCreator));
      if(session == null)
        throw new ArgumentNullException(nameof(session));

      this.session = session;
      this.dbCreator = dbCreator;
      this.dataCreator = dataCreator;
    }
  }
}
