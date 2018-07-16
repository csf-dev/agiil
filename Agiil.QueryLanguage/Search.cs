using System;
namespace Agiil.QueryLanguage
{
  public class Search
  {
    Criteria criteria;
    Ordering ordering;

    public Criteria Criteria
    {
      get { return criteria; }
      set { criteria = value ?? new Criteria(); }
    }

    public Ordering Ordering
    {
      get { return ordering; }
      set { ordering = value ?? new Ordering(); }
    }

    public Search()
    {
      criteria = new Criteria();
      ordering = new Ordering();
    }
  }
}
