using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  public interface IResolvesValue
  {
    TResolvedValue Resolve<TResolvedValue>(Value value);

    IReadOnlyList<TResolvedValue> ResolveAll<TResolvedValue>(IReadOnlyList<Value> values);

    IReadOnlyList<TResolvedValue> ResolveAll<TResolvedValue>(IList<Value> values);
  }
}
