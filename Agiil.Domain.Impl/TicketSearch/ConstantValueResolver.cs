using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Domain.TicketSearch
{
  public class ConstantValueResolver : IResolvesValue
  {
    public TResolvedValue Resolve<TResolvedValue>(Value value)
    {
      var constant = value as ConstantValue;
      if(constant == null) return default(TResolvedValue);

      var val = constant.Text;
      try
      {
        return (TResolvedValue) Convert.ChangeType(val, typeof(TResolvedValue));
      }
      catch(Exception)
      {
        return default(TResolvedValue);
      }
    }

    public IReadOnlyList<TResolvedValue> ResolveAll<TResolvedValue>(IReadOnlyList<Value> values)
      => ResolveAllValues<TResolvedValue>(values);

    public IReadOnlyList<TResolvedValue> ResolveAll<TResolvedValue>(IList<Value> values)
      => ResolveAllValues<TResolvedValue>(values);

    IReadOnlyList<TResolvedValue> ResolveAllValues<TResolvedValue>(IEnumerable<Value> values)
      => values?.Select(x => Resolve<TResolvedValue>(x))?.ToArray() ?? new TResolvedValue[0];
  }
}
