using System;
using Autofac.Features.OwnedInstances;

namespace Agiil.Domain.Data
{
  public class OwnedTransactionWrapper : INestableTransaction
  {
    #region fields

    bool isDisposed;
    readonly Owned<INestableTransaction> underlyingTransaction;

    #endregion

    #region INestableTransaction implementation

    public bool IsOutermostTransaction => underlyingTransaction.Value.IsOutermostTransaction;

    public bool ShouldTriggerParentRollback => underlyingTransaction.Value.ShouldTriggerParentRollback;

    public void AddChild(INestableTransaction transaction)
    {
      underlyingTransaction.Value.AddChild(transaction);
    }

    public void RequestCommit()
    {
      underlyingTransaction.Value.RequestCommit();
    }

    public void Rollback()
    {
      underlyingTransaction.Value.Rollback();
    }

    #endregion

    #region IDisposable Support

    protected virtual void Dispose(bool disposing)
    {
      if(!isDisposed)
      {
        if(disposing)
        {
          underlyingTransaction.Dispose();
        }

        isDisposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
    }

    #endregion

    #region constructor

    public OwnedTransactionWrapper(Owned<INestableTransaction> underlyingTransaction)
    {
      if(underlyingTransaction == null)
        throw new ArgumentNullException(nameof(underlyingTransaction));

      this.underlyingTransaction = underlyingTransaction;
    }

    #endregion
  }
}
