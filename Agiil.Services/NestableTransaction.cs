using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using Agiil.Domain;

namespace Agiil.Services
{
  public class NestableTransaction : INestableTransaction, IDisposable
  {
    #region fields

    bool isDisposed;
    readonly ITransaction transaction;
    readonly ISet<INestableTransaction> childTransactions;

    #endregion

    #region INestableTransaction implementation

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Agiil.Domain.INestableTransaction"/> is the outermost transaction.
    /// </summary>
    /// <value><c>true</c> if this is the outermost transaction; otherwise, <c>false</c>.</value>
    public virtual bool IsOutermostTransaction => Transaction != null;

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Agiil.Services.INestableTransaction"/> should trigger a rollback
    /// of any parent transactions (if applicable).
    /// </summary>
    /// <value><c>true</c> if this transaction should trigger a rollback; otherwise, <c>false</c>.</value>
    public virtual bool ShouldTriggerParentRollback
    {
      get {
        if(IsOutermostTransaction)
        {
          return false;
        }

        return (!CommitState.GetValueOrDefault(false)
                || HasChildrenWhichTriggerRollback);
      }
    }

    /// <summary>
    /// Indicates that the transaction should be committed.
    /// The underlying database transaction will only be committed if this is the outermost level of nesting AND
    /// also, no child transactions indicate that they should <see cref="ShouldTriggerParentRollback"/>.
    /// If child transactions indicate rollback, then this operation will in fact result in a rollback.
    /// </summary>
    public virtual void RequestCommit()
    {
      if(IsOutermostTransaction)
      {
        if(HasChildrenWhichTriggerRollback)
        {
          transaction.Rollback();
        }
        else
        {
          transaction.Commit();
        }
      }

      SetCommitState(true);
    }

    /// <summary>
    /// Indicates that the transaction should be rolled back.
    /// If this is the outermost transaction then it will trigger an immediate rollback.
    /// If it is a nested transaction then it indicates to the outermost transaction that it should cause a rollback.
    /// </summary>
    public virtual void Rollback()
    {
      if(IsOutermostTransaction)
      {
        transaction.Rollback();
      }

      SetCommitState(false);
    }

    /// <summary>
    /// Adds a child transaction to the current instance.  The child transaction must not be an outer transaction.
    /// </summary>
    /// <param name="transaction">Transaction.</param>
    public virtual void AddChild(INestableTransaction transaction)
    {
      if(transaction == null)
        throw new ArgumentNullException(nameof(transaction));

      if(transaction.IsOutermostTransaction)
        throw new CannotNestOutermostTransactionException(Resources.ExceptionMessages.CannotNestOutermostTransaction);

      childTransactions.Add(transaction);
    }

    #endregion

    #region other functionality

    public virtual bool? CommitState { get; private set; }

    public virtual IEnumerable<INestableTransaction> ChildTransactions => childTransactions;

    protected virtual bool HasChildrenWhichTriggerRollback =>
      ChildTransactions.Any(x => x.ShouldTriggerParentRollback);

    protected virtual ITransaction Transaction => transaction;

    protected virtual void SetCommitState(bool commit)
    {
      if(CommitState.HasValue)
      {
        throw new TransactionAlreadyFinalizedException(Resources.ExceptionMessages.TransactionAlreadyFinalized);
      }
      else
      {
        CommitState = commit;
      }
    }

    #endregion

    #region IDisposable Support

    protected virtual void Dispose(bool disposing)
    {
      if(!isDisposed)
      {
        if(transaction != null)
        {
          transaction.Dispose();
        }

        isDisposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    #endregion

    #region constructors & destructors

    public NestableTransaction()
    {
      childTransactions = new HashSet<INestableTransaction>();
    }

    public NestableTransaction(ITransaction transaction) : this()
    {
      if(transaction == null)
        throw new ArgumentNullException(nameof(transaction));
      
      this.transaction = transaction;
    }

    ~NestableTransaction() {
      Dispose(false);
    }

    #endregion
  }
}
