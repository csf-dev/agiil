using System;
using Agiil.Domain.Data;

namespace Agiil.Data
{
  public interface ICurrentTransactionReader
  {
    INestableTransaction CurrentTransaction { get; }
  }
}
