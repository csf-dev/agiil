using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using Agiil.Web.Controllers;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using CSF.Entities;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  public class TicketQueryController : ITicketQueryController
  {
    readonly IRepository<Ticket> repo;
    readonly IRepository<Sprint> sprintRepo;

    public bool DoesTicketExist(TicketSearchCriteria criteria = null)
    {
      var query = repo.Query();
      query = ApplyCriteria(query, criteria);
      return query.AnyCount();
    }

    IQueryable<Ticket> ApplyCriteria(IQueryable<Ticket> query, TicketSearchCriteria criteria)
    {
      if(criteria == null)
        return query;

      if(!String.IsNullOrEmpty(criteria.Title))
        query = query.Where(x => x.Title == criteria.Title);

      if(!String.IsNullOrEmpty(criteria.Description))
        query = query.Where(x => x.Description == criteria.Description);

      if(!String.IsNullOrEmpty(criteria.User))
        query = query.Where(x => x.User != null && x.User.Username == criteria.User);

      if(criteria.Sprint.HasValue)
      {
        var sprint = sprintRepo.Theorise(Identity.Create<Sprint>(criteria.Sprint.Value));
        query = query.Where(x => x.Sprint == sprint);
      }

      return query;
    }

    Expression<Func<Ticket,bool>> CreateTicketSearchPredicate(TicketSearchCriteria helper)
    {
      if(helper == null)
        return t => true;

      return t => (((helper.Title == null) || t.Title == helper.Title.Trim())
                   && ((helper.Description == null) || t.Description == helper.Description.Trim())
                   && ((helper.User == null) || (t.User != null && t.User.Username == helper.User.Trim())));

    }

    public TicketQueryController(IRepository<Ticket> repo,
                                 IRepository<Sprint> sprintRepo)
    {
      if(sprintRepo == null)
        throw new ArgumentNullException(nameof(sprintRepo));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));

      this.repo = repo;
      this.sprintRepo = sprintRepo;
    }
  }
}
