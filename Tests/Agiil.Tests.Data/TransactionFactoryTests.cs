using NUnit.Framework;
using System;
using Agiil.Data;
using Ploeh.AutoFixture.NUnit3;
using NHibernate;
using Autofac.Features.OwnedInstances;
using Agiil.Domain.Data;
using Moq;

namespace Agiil.Tests.Data
{
  [TestFixture]
  public class TransactionFactoryTests
  {
    [Test,AutoMoqData]
    public void BeginTransaction_begins_nhibernate_transaction_when_there_is_no_transaction_already(ICurrentTransactionReader transactionReader,
                                                                                                    ISession session,
                                                                                                    ITransaction nhTrans,
                                                                                                    Owned<INestableTransaction> createdTrans,
                                                                                                    OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns((INestableTransaction) null);
      Mock.Get(session)
          .Setup(x => x.BeginTransaction())
          .Returns(nhTrans);

      var sut = new TransactionFactory(transactionReader, t => createdTrans, t => wrapper, session);

      // Act
      sut.BeginTransaction();

      // Assert
      Mock.Get(session).Verify(x => x.BeginTransaction(), Times.Once());
    }

    [Test,AutoMoqData]
    public void BeginTransaction_does_not_begin_nhibernate_transaction_when_there_is_a_transaction_already(ICurrentTransactionReader transactionReader,
                                                                                                           ISession session,
                                                                                                           INestableTransaction existing,
                                                                                                           Owned<INestableTransaction> createdTrans,
                                                                                                           OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns(existing);
      Mock.Get(session).Setup(x => x.BeginTransaction());

      var sut = new TransactionFactory(transactionReader, t => createdTrans, t => wrapper, session);

      // Act
      sut.BeginTransaction();

      // Assert
      Mock.Get(session).Verify(x => x.BeginTransaction(), Times.Never());
    }

    [Test,AutoMoqData]
    public void BeginTransaction_passes_nhibernate_transaction_to_creation_function_for_outer_transactions(ICurrentTransactionReader transactionReader,
                                                                                                           ISession session,
                                                                                                           ITransaction nhTrans,
                                                                                                           Owned<INestableTransaction> createdTrans,
                                                                                                           OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns((INestableTransaction) null);
      Mock.Get(session)
          .Setup(x => x.BeginTransaction())
          .Returns(nhTrans);

      ITransaction capturedTransaction = null;
      Func<ITransaction,Owned<INestableTransaction>> transactionCreator;
      transactionCreator = t => {
        capturedTransaction = t;
        return createdTrans;
      };

      var sut = new TransactionFactory(transactionReader, transactionCreator, t => wrapper, session);

      // Act
      sut.BeginTransaction();

      // Assert
      Assert.AreSame(nhTrans, capturedTransaction);
    }

    [Test,AutoMoqData]
    public void BeginTransaction_passes_null_to_creation_function_for_child_transactions(ICurrentTransactionReader transactionReader,
                                                                                         ISession session,
                                                                                         INestableTransaction existing,
                                                                                         Owned<INestableTransaction> createdTrans,
                                                                                         OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns(existing);

      ITransaction capturedTransaction = null;
      Func<ITransaction,Owned<INestableTransaction>> transactionCreator;
      transactionCreator = t => {
        capturedTransaction = t;
        return createdTrans;
      };

      var sut = new TransactionFactory(transactionReader, transactionCreator, t => wrapper, session);

      // Act
      sut.BeginTransaction();

      // Assert
      Assert.IsNull(capturedTransaction);
    }

    [Test,AutoMoqData]
    public void BeginTransaction_wraps_outer_transactions(ICurrentTransactionReader transactionReader,
                                                          ISession session,
                                                          ITransaction nhTrans,
                                                          Owned<INestableTransaction> createdTrans,
                                                          OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns((INestableTransaction) null);
      Mock.Get(session)
          .Setup(x => x.BeginTransaction())
          .Returns(nhTrans);

      Owned<INestableTransaction> capturedTransaction = null;
      Func<Owned<INestableTransaction>,OwnedTransactionWrapper> transactionCreator;
      transactionCreator = t => {
        capturedTransaction = t;
        return wrapper;
      };

      var sut = new TransactionFactory(transactionReader, t => createdTrans, transactionCreator, session);

      // Act
      sut.BeginTransaction();

      // Assert
      Assert.AreSame(createdTrans, capturedTransaction);
    }

    [Test,AutoMoqData]
    public void BeginTransaction_wraps_child_transactions(ICurrentTransactionReader transactionReader,
                                                          ISession session,
                                                          INestableTransaction existing,
                                                          Owned<INestableTransaction> createdTrans,
                                                          OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns(existing);

      Owned<INestableTransaction> capturedTransaction = null;
      Func<Owned<INestableTransaction>,OwnedTransactionWrapper> transactionCreator;
      transactionCreator = t => {
        capturedTransaction = t;
        return wrapper;
      };

      var sut = new TransactionFactory(transactionReader, t => createdTrans, transactionCreator, session);

      // Act
      sut.BeginTransaction();

      // Assert
      Assert.AreSame(createdTrans, capturedTransaction);
    }

    [Test,AutoMoqData]
    public void BeginTransaction_adds_new_child_transaction_to_parent(ICurrentTransactionReader transactionReader,
                                                                      ISession session,
                                                                      INestableTransaction existing,
                                                                      Owned<INestableTransaction> createdTrans,
                                                                      OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns(existing);
      Mock.Get(existing)
          .Setup(x => x.AddChild(It.IsAny<INestableTransaction>()));

      var sut = new TransactionFactory(transactionReader, t => createdTrans, t => wrapper, session);

      // Act
      sut.BeginTransaction();

      // Assert
      Mock.Get(existing).Verify(x => x.AddChild(createdTrans.Value), Times.Once());
    }

    [Test,AutoMoqData]
    public void BeginTransaction_returns_outer_transaction_wrapper(ICurrentTransactionReader transactionReader,
                                                                   ISession session,
                                                                   ITransaction nhTrans,
                                                                   Owned<INestableTransaction> createdTrans,
                                                                   OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns((INestableTransaction) null);
      Mock.Get(session)
          .Setup(x => x.BeginTransaction())
          .Returns(nhTrans);

      var sut = new TransactionFactory(transactionReader, t => createdTrans, t => wrapper, session);

      // Act
      var result = sut.BeginTransaction();

      // Assert
      Assert.AreSame(wrapper, result);
    }

    [Test,AutoMoqData]
    public void BeginTransaction_returns_child_transaction_wrapper(ICurrentTransactionReader transactionReader,
                                                                   ISession session,
                                                                   INestableTransaction existing,
                                                                   Owned<INestableTransaction> createdTrans,
                                                                   OwnedTransactionWrapper wrapper)
    {
      // Arrange
      Mock.Get(transactionReader)
          .SetupGet(x => x.CurrentTransaction)
          .Returns(existing);

      var sut = new TransactionFactory(transactionReader, t => createdTrans, t => wrapper, session);

      // Act
      var result = sut.BeginTransaction();

      // Assert
      Assert.AreSame(wrapper, result);
    }
  }
}
