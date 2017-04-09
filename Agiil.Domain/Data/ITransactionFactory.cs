using System;

namespace Agiil.Domain.Data
{
  public interface ITransactionFactory
  {
    INestableTransaction BeginTransaction();
  }
}
