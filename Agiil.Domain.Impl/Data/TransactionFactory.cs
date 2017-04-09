using System;
using Autofac.Features.OwnedInstances;
using NHibernate;

namespace Agiil.Domain.Data
{
  public class TransactionFactory : ITransactionFactory
  {
    readonly ICurrentTransactionReader currentTransactionReader;
    readonly Func<ITransaction,Owned<INestableTransaction>> transactionCreator;
    readonly Func<Owned<INestableTransaction>,OwnedTransactionWrapper> transactionWrapperCreator;
    readonly ISession session;

    public INestableTransaction BeginTransaction()
    {
      var currentTransaction = GetCurrentTransaction();

      if(currentTransaction == null)
      {
        return CreateOuterTransaction();
      }

      return CreateChildTransaction(currentTransaction);
    }

    INestableTransaction GetCurrentTransaction()
    {
      return currentTransactionReader.CurrentTransaction;
    }

    INestableTransaction CreateOuterTransaction()
    {
      var nhibernateTransaction = session.BeginTransaction();
      var ownedTransaction = transactionCreator(nhibernateTransaction);
      return transactionWrapperCreator(ownedTransaction);
    }

    INestableTransaction CreateChildTransaction(INestableTransaction parent)
    {
      var ownedTransaction = transactionCreator(null);
      parent.AddChild(ownedTransaction.Value);
      return transactionWrapperCreator(ownedTransaction);
    }

    public TransactionFactory(ICurrentTransactionReader currentTransactionReader,
                              Func<ITransaction,Owned<INestableTransaction>> transactionCreator,
                              Func<Owned<INestableTransaction>,OwnedTransactionWrapper> transactionWrapperCreator,
                              ISession session)
    {
      if(session == null)
        throw new ArgumentNullException(nameof(session));
      if(transactionWrapperCreator == null)
        throw new ArgumentNullException(nameof(transactionWrapperCreator));
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(currentTransactionReader == null)
        throw new ArgumentNullException(nameof(currentTransactionReader));

      this.currentTransactionReader = currentTransactionReader;
      this.transactionCreator = transactionCreator;
      this.transactionWrapperCreator = transactionWrapperCreator;
      this.session = session;
    }
  }
}
