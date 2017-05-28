using System;
using System.Collections;
using System.Collections.Generic;

namespace Agiil.Tests
{
  public abstract class TestComparerBase<TCompared> : IEqualityComparer<TCompared>, IComparer where TCompared : class
  {
    public virtual int Compare(object x, object y)
    {
      if(ReferenceEquals(x, y))
        return 0;

      TCompared
        first = x as TCompared,
        second = y as TCompared;

      if(ReferenceEquals(first, null))
        return -1;
      if(ReferenceEquals(second, null))
        return 1;

      if(Equals(first, second))
        return 0;

      return CompareNonNullInstances(first, second);
    }

    protected abstract int CompareNonNullInstances(TCompared first, TCompared second);

    public virtual bool Equals(TCompared x, TCompared y)
    {
      if(ReferenceEquals(x, y))
        return true;
      if(ReferenceEquals(x, null))
        return false;
      if(ReferenceEquals(y, null))
        return false;

      return AreNonNullInstancesEqual(x, y);
    }

    protected abstract bool AreNonNullInstancesEqual(TCompared x, TCompared y);

    public virtual int GetHashCode(TCompared obj)
    {
      if(ReferenceEquals(obj, null))
        return 0;
      
      return GetHashCodeForNonNullInstance(obj);
    }

    protected abstract int GetHashCodeForNonNullInstance(TCompared obj);
  }
}
