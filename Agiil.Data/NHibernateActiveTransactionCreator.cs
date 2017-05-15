using System;
using CSF.Data;
using CSF.Data.NHibernate;
using NHibernate;

namespace Agiil.Data
{
  public class NHibernateActiveTransactionCreator : ITransactionCreator
  {
    //
    // Fields
    //
    readonly ISession session;

    //
    // Constructors
    //
    public NHibernateActiveTransactionCreator (ISession session)
    {
      if (session == null) {
        throw new ArgumentNullException (nameof(session));
      }

      this.session = session;
    }

    //
    // Methods
    //
    public CSF.Data.ITransaction BeginTransaction ()
    {
      if (session.Transaction != null && session.Transaction.IsActive) {
        return new SubordinateTransactionWrapper (session.Transaction);
      }
      return new TransactionWrapper (session.BeginTransaction ());
    }
  }
}
