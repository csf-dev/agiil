using System;
using System.Linq;
using System.Linq.Expressions;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using Agiil.Domain.Tickets;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using CSF.Entities;
using NUnit.Framework;

namespace Agiil.Tests.Sprints
{
  public class SprintQueryController : ISprintQueryController
  {
    readonly IRepository<Sprint> repo;
    readonly IRepository<Project> projectRepo;
    readonly ITicketReferenceQuery ticketQuery;

    public bool DoesSprintExist(SprintSearchCriteria criteria = null)
    {
      var query = repo.Query();
      query = ApplyCriteria(query, criteria);
      return query.AnyCount();
    }

    public void AssertThatTicketIsPartOfSprint(string ticketReference, string sprintName)
    {
      var ticket = ticketQuery.GetTicketByReference(ticketReference);

      if(ticket == null)
        Assert.Fail($"Ticket reference {ticketReference} was not found; it is required for this assertion.");

      if(ticket.Sprint == null)
        Assert.Fail($"Ticket reference {ticketReference} is not added to any sprint, it was expected to part of '{sprintName}'.");

      Assert.AreEqual(sprintName, ticket.Sprint.Name);
    }

    public void AssertThatTicketIsNotPartOfAnySprint(string ticketReference)
    {
      var ticket = ticketQuery.GetTicketByReference(ticketReference);

      if(ticket == null)
        Assert.Fail($"Ticket reference {ticketReference} was not found; it is required for this assertion.");

      Assert.IsNull(ticket.Sprint);
    }

    IQueryable<Sprint> ApplyCriteria(IQueryable<Sprint> query, SprintSearchCriteria criteria)
    {
      if(criteria == null)
        return query;

      if(!String.IsNullOrEmpty(criteria.Name))
        query = query.Where(x => x.Name == criteria.Name);

      if(!String.IsNullOrEmpty(criteria.Description))
        query = query.Where(x => x.Description == criteria.Description);

      if(criteria.Project.HasValue)
      {
        var projectId = Identity.Create<Project>(criteria.Project.Value);
        var project = projectRepo.Theorise(projectId);
        query = query.Where(x => x.Project == project);
      }

      if(criteria.StartDate.HasValue)
        query = query.Where(x => x.StartDate == criteria.StartDate.Value);

      if(criteria.EndDate.HasValue)
        query = query.Where(x => x.EndDate == criteria.EndDate.Value);

      return query;
    }

    public SprintQueryController(IRepository<Sprint> repo,
                                 IRepository<Project> projectRepo,
                                 ITicketReferenceQuery ticketQuery)
    {
      if(ticketQuery == null)
        throw new ArgumentNullException(nameof(ticketQuery));
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
      this.projectRepo = projectRepo;
      this.ticketQuery = ticketQuery;
    }
  }
}
