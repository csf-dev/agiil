using System;
namespace Agiil.Domain.Data
{
  /// <summary>
  /// Interface represents a unit of logical work, which is loosely connected to a database transaction.
  /// This type of transaction may be nested though; the semantics of which are that the underlying database transaction
  /// is only committed when the outermost nesting level is committed.
  /// </summary>
  public interface INestableTransaction : IDisposable
  {
    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Agiil.Services.INestableTransaction"/> should trigger a rollback
    /// of any parent transactions (if applicable).
    /// </summary>
    /// <value><c>true</c> if this transaction should trigger a rollback; otherwise, <c>false</c>.</value>
    bool ShouldTriggerParentRollback { get; }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Agiil.Domain.INestableTransaction"/> is the outermost transaction.
    /// </summary>
    /// <value><c>true</c> if this is the outermost transaction; otherwise, <c>false</c>.</value>
    bool IsOutermostTransaction { get; }

    /// <summary>
    /// Requests that the transaction be committed.
    /// The underlying database transaction will only be committed if this is the outermost level of nesting AND
    /// also, no child transactions indicate that they should <see cref="ShouldTriggerParentRollback"/>.
    /// If child transactions indicate rollback, then this operation will in fact result in a rollback.
    /// </summary>
    void RequestCommit();

    /// <summary>
    /// Indicates that the transaction should be rolled back.
    /// If this is the outermost transaction then it will trigger an immediate rollback.
    /// If it is a nested transaction then it indicates to the outermost transaction that it should cause a rollback.
    /// </summary>
    void Rollback();

    /// <summary>
    /// Adds a child transaction to the current instance.  The child transaction must not be an outer transaction.
    /// </summary>
    /// <param name="transaction">Transaction.</param>
    void AddChild(INestableTransaction transaction);
  }
}
