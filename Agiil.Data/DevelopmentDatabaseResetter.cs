using System;
using Agiil.Domain.Data;
using NHibernate;

namespace Agiil.Data
{
  public class DevelopmentDatabaseResetter : IDatabaseResetter
  {
    readonly ISession session;
    readonly IDatabaseCreator dbCreator;
    readonly IInitialDataCreator dataCreator;

    public void ResetDatabase()
    {
      var connection = session.Connection;
      dbCreator.Create(connection, null);
      dataCreator.Create();
    }

    public DevelopmentDatabaseResetter(ISession session,
                                       IDatabaseCreator dbCreator,
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
