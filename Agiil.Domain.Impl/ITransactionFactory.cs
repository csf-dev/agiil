using System;
using Agiil.Domain;
using NHibernate;

namespace Agiil.Domain
{
  public interface ITransactionFactory
  {
    INestableTransaction BeginTransaction(ISession session);
  }
}
