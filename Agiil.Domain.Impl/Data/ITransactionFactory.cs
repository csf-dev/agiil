using System;
using Agiil.Domain;
using NHibernate;

namespace Agiil.Domain.Data
{
  public interface ITransactionFactory
  {
    INestableTransaction BeginTransaction();
  }
}
