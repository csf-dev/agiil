using System;
namespace Agiil.Domain.Data
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
