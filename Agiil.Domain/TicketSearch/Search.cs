using System;
namespace Agiil.Domain.TicketSearch
{
  public class Search
  {
    CriteriaRoot criteria;
    Ordering ordering;

    public CriteriaRoot CriteriaRoot
    {
      get { return criteria; }
      set { criteria = value ?? new CriteriaRoot(); }
    }

    public Ordering Ordering
    {
      get { return ordering; }
      set { ordering = value ?? new Ordering(); }
    }

    public Search()
    {
      criteria = new CriteriaRoot();
      ordering = new Ordering();
    }
  }
}
