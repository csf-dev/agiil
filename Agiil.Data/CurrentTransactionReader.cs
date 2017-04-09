using System;
using Agiil.Domain.Data;

namespace Agiil.Data
{
  public class CurrentTransactionReader : ICurrentTransactionReader
  {
    readonly OwnedTransactionWrapper current;

    public INestableTransaction CurrentTransaction => current;

    public CurrentTransactionReader(OwnedTransactionWrapper current)
    {
      if(current == null)
        throw new ArgumentNullException(nameof(current));

      this.current = current;
    }
  }
}
