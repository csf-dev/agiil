using System;
using System.Linq.Expressions;
using Agiil.Domain.Tickets;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Data.NHibernate;

namespace Agiil.Tests.Tickets
{
  public class TicketQueryController : ITicketQueryController
  {
    readonly IRepository<Ticket> repo;

    public bool DoesTicketExist(TicketSearchCriteria searchHelper = null)
    {
      var predicate = CreateTicketSearchPredicate(searchHelper);
      return repo.Query().AnyCount(predicate);
    }

    Expression<Func<Ticket,bool>> CreateTicketSearchPredicate(TicketSearchCriteria helper)
    {
      if(helper == null)
        return t => true;

      return t => ((String.IsNullOrWhiteSpace(helper.Title) || t.Title == helper.Title.Trim())
                   && (String.IsNullOrWhiteSpace(helper.Description) || t.Description == helper.Description.Trim())
                   && (String.IsNullOrWhiteSpace(helper.User) || (t.User != null && t.User.Username == helper.User.Trim())));

    }

    public TicketQueryController(IRepository<Ticket> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));

      this.repo = repo;
    }
  }
}
