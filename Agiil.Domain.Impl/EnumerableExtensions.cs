using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.Specifications;

namespace Agiil.Domain
{
  public static class EnumerableExtensions
  {
    public static bool Any<T> (this IEnumerable<T> sourceQuery, ISpecification<T> specification)
    {
      return sourceQuery.Where (specification).Any<T> ();
    }

    public static int Count<T> (this IEnumerable<T> sourceQuery, ISpecification<T> specification)
    {
      return sourceQuery.Where (specification).Count<T> ();
    }

    public static T First<T> (this IEnumerable<T> sourceQuery, ISpecification<T> specification)
    {
      return sourceQuery.Where (specification).First<T> ();
    }

    public static T FirstOrDefault<T> (this IEnumerable<T> sourceQuery, ISpecification<T> specification)
    {
      return sourceQuery.Where (specification).FirstOrDefault<T> ();
    }

    public static T Single<T> (this IEnumerable<T> sourceQuery, ISpecification<T> specification)
    {
      return sourceQuery.Where (specification).Single<T> ();
    }

    public static T SingleOrDefault<T> (this IEnumerable<T> sourceQuery, ISpecification<T> specification)
    {
      return sourceQuery.Where (specification).SingleOrDefault<T> ();
    }

    public static IEnumerable<T> Where<T> (this IEnumerable<T> sourceQuery, ISpecification<T> specification)
    {
      if (specification == null) {
        throw new ArgumentNullException (nameof(specification));
      }
      return sourceQuery.Where(x => specification.Matches(x));
    }

    public static bool Any<T> (this IEnumerable<T> sourceQuery, ISpecificationExpression<T> specification)
    {
      return sourceQuery.Where (specification).Any<T> ();
    }

    public static int Count<T> (this IEnumerable<T> sourceQuery, ISpecificationExpression<T> specification)
    {
      return sourceQuery.Where (specification).Count<T> ();
    }

    public static T First<T> (this IEnumerable<T> sourceQuery, ISpecificationExpression<T> specification)
    {
      return sourceQuery.Where (specification).First<T> ();
    }

    public static T FirstOrDefault<T> (this IEnumerable<T> sourceQuery, ISpecificationExpression<T> specification)
    {
      return sourceQuery.Where (specification).FirstOrDefault<T> ();
    }

    public static T Single<T> (this IEnumerable<T> sourceQuery, ISpecificationExpression<T> specification)
    {
      return sourceQuery.Where (specification).Single<T> ();
    }

    public static T SingleOrDefault<T> (this IEnumerable<T> sourceQuery, ISpecificationExpression<T> specification)
    {
      return sourceQuery.Where (specification).SingleOrDefault<T> ();
    }

    public static IEnumerable<T> Where<T> (this IEnumerable<T> sourceQuery, ISpecificationExpression<T> specification)
    {
      if (specification == null) {
        throw new ArgumentNullException (nameof(specification));
      }
      return sourceQuery.Where(specification.GetExpression().Compile());
    }
  }
}
