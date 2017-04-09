using System;
namespace Agiil.Domain.Data
{
  public interface ICurrentTransactionReader
  {
    INestableTransaction CurrentTransaction { get; }
  }
}
