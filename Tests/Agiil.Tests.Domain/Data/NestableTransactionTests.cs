using NUnit.Framework;
using System;
using Agiil.Domain.Data;
using NHibernate;
using Moq;

namespace Agiil.Tests.Domain.Data
{
  [TestFixture]
  public class NestableTransactionTests
  {
    [Test,AutoMoqData]
    public void IsOutermostTransaction_returns_true_when_an_underlying_transaction_is_present(ITransaction underlying)
    {
      // Arrange
      var sut = new NestableTransaction(underlying);

      // Act
      var result = sut.IsOutermostTransaction;

      // Assert
      Assert.IsTrue(result);
    }

    [Test,AutoMoqData]
    public void IsOutermostTransaction_returns_false_when_an_underlying_transaction_is_not_present()
    {
      // Arrange
      var sut = new NestableTransaction();

      // Act
      var result = sut.IsOutermostTransaction;

      // Assert
      Assert.IsFalse(result);
    }

    [Test,AutoMoqData]
    public void ShouldTriggerParentRollback_returns_false_for_outermost_transactions(ITransaction underlying)
    {
      // Arrange
      var sut = new NestableTransaction(underlying);

      // Act
      var result = sut.ShouldTriggerParentRollback;

      // Assert
      Assert.IsFalse(result);
    }

    [Test,AutoMoqData]
    public void ShouldTriggerParentRollback_returns_false_for_committed_transaction_with_empty_child_transactions()
    {
      // Arrange
      var sut = new NestableTransaction();
      sut.RequestCommit();

      // Act
      var result = sut.ShouldTriggerParentRollback;

      // Assert
      Assert.IsFalse(result);
    }

    [Test,AutoMoqData]
    public void ShouldTriggerParentRollback_returns_false_for_committed_transaction_when_child_transaction_indicates_commit(INestableTransaction childOne)
    {
      // Arrange
      var sut = new NestableTransaction();
      sut.AddChild(childOne);
      sut.RequestCommit();

      Mock.Get(childOne)
          .SetupGet(x => x.ShouldTriggerParentRollback)
          .Returns(false);

      // Act
      var result = sut.ShouldTriggerParentRollback;

      // Assert
      Assert.IsFalse(result);
    }

    [Test,AutoMoqData]
    public void ShouldTriggerParentRollback_returns_true_for_committed_transaction_when_child_transaction_indicates_rollback(INestableTransaction childOne)
    {
      // Arrange
      var sut = new NestableTransaction();
      sut.AddChild(childOne);
      sut.RequestCommit();

      Mock.Get(childOne)
          .SetupGet(x => x.ShouldTriggerParentRollback)
          .Returns(true);

      // Act
      var result = sut.ShouldTriggerParentRollback;

      // Assert
      Assert.IsTrue(result);
    }

    [Test,AutoMoqData]
    public void ShouldTriggerParentRollback_returns_true_if_transaction_is_not_committed()
    {
      // Arrange
      var sut = new NestableTransaction();

      // Act
      var result = sut.ShouldTriggerParentRollback;

      // Assert
      Assert.IsTrue(result);
    }

    [Test,AutoMoqData]
    public void ShouldTriggerParentRollback_returns_true_if_transaction_is_rolled_back()
    {
      // Arrange
      var sut = new NestableTransaction();
      sut.Rollback();

      // Act
      var result = sut.ShouldTriggerParentRollback;

      // Assert
      Assert.IsTrue(result);
    }

    [Test,AutoMoqData]
    public void RequestCommit_commits_underlying_transaction_when_no_child_transactions_present(ITransaction underlying)
    {
      // Arrange
      Mock.Get(underlying).Setup(x => x.Commit());
      var sut = new NestableTransaction(underlying);

      // Act
      sut.RequestCommit();

      // Assert
      Mock.Get(underlying).Verify(x => x.Commit(), Times.Once());
      Mock.Get(underlying).Verify(x => x.Rollback(), Times.Never());
    }

    [Test,AutoMoqData]
    public void RequestCommit_commits_underlying_transaction_when_child_transaction_does_not_rollback(ITransaction underlying,
                                                                                                      INestableTransaction childOne)
    {
      // Arrange
      Mock.Get(underlying).Setup(x => x.Commit());
      Mock.Get(childOne)
          .SetupGet(x => x.ShouldTriggerParentRollback)
          .Returns(false);
      
      var sut = new NestableTransaction(underlying);
      sut.AddChild(childOne);

      // Act
      sut.RequestCommit();

      // Assert
      Mock.Get(underlying).Verify(x => x.Commit(), Times.Once());
      Mock.Get(underlying).Verify(x => x.Rollback(), Times.Never());
    }

    [Test,AutoMoqData]
    public void RequestCommit_rollsback_underlying_transaction_when_child_transaction_indicates_rollback(ITransaction underlying,
                                                                                                         INestableTransaction childOne)
    {
      // Arrange
      Mock.Get(underlying).Setup(x => x.Commit());
      Mock.Get(underlying).Setup(x => x.Rollback());
      Mock.Get(childOne)
          .SetupGet(x => x.ShouldTriggerParentRollback)
          .Returns(true);
      
      var sut = new NestableTransaction(underlying);
      sut.AddChild(childOne);

      // Act
      sut.RequestCommit();

      // Assert
      Mock.Get(underlying).Verify(x => x.Commit(), Times.Never());
      Mock.Get(underlying).Verify(x => x.Rollback(), Times.Once());
    }

    [Test,AutoMoqData]
    public void Rollback_rollsback_underlying_transaction(ITransaction underlying)
    {
      // Arrange
      Mock.Get(underlying).Setup(x => x.Commit());
      Mock.Get(underlying).Setup(x => x.Rollback());
      var sut = new NestableTransaction(underlying);

      // Act
      sut.Rollback();

      // Assert
      Mock.Get(underlying).Verify(x => x.Commit(), Times.Never());
      Mock.Get(underlying).Verify(x => x.Rollback(), Times.Once());
    }

    [Test,AutoMoqData]
    public void RequestCommit_sets_commit_state_to_true_when_child_transaction_does_not_rollback(INestableTransaction childOne)
    {
      // Arrange
      Mock.Get(childOne)
          .SetupGet(x => x.ShouldTriggerParentRollback)
          .Returns(false);
      
      var sut = new NestableTransaction();
      sut.AddChild(childOne);

      // Act
      sut.RequestCommit();

      // Assert
      Assert.IsTrue(sut.CommitState);
    }

    [Test,AutoMoqData]
    public void RequestCommit_sets_commit_state_to_true_when_child_transaction_indicates_rollback(INestableTransaction childOne)
    {
      // Arrange
      Mock.Get(childOne)
          .SetupGet(x => x.ShouldTriggerParentRollback)
          .Returns(true);
      
      var sut = new NestableTransaction();
      sut.AddChild(childOne);

      // Act
      sut.RequestCommit();

      // Assert
      Assert.IsTrue(sut.CommitState);
    }

    [Test,AutoMoqData]
    public void Rollback_sets_commit_state_to_false()
    {
      // Arrange
      var sut = new NestableTransaction();

      // Act
      sut.Rollback();

      // Assert
      Assert.IsFalse(sut.CommitState);
    }

    [Test,AutoMoqData]
    public void Rollback_throws_exception_if_called_twice()
    {
      // Arrange
      var sut = new NestableTransaction();
      sut.Rollback();

      // Act & assert
      Assert.Throws<TransactionAlreadyFinalizedException>(() => sut.Rollback());
    }

    [Test,AutoMoqData]
    public void RequestCommit_throws_exception_if_called_twice()
    {
      // Arrange
      var sut = new NestableTransaction();
      sut.RequestCommit();

      // Act & assert
      Assert.Throws<TransactionAlreadyFinalizedException>(() => sut.RequestCommit());
    }

    [Test,AutoMoqData]
    public void AddChild_adds_to_child_transactions_collection(INestableTransaction child)
    {
      // Arrange
      Mock.Get(child)
          .SetupGet(x => x.IsOutermostTransaction)
          .Returns(false);
      
      var sut = new NestableTransaction();

      // Act
      sut.AddChild(child);

      // Assert
      CollectionAssert.Contains(sut.ChildTransactions, child);
    }

    [Test,AutoMoqData]
    public void AddChild_throws_exception_if_child_is_an_outer_transaction(INestableTransaction child)
    {
      // Arrange
      Mock.Get(child)
          .SetupGet(x => x.IsOutermostTransaction)
          .Returns(true);
      
      var sut = new NestableTransaction();

      // Act & assert
      Assert.Throws<CannotNestOutermostTransactionException>(() => sut.AddChild(child));
    }
  }
}
