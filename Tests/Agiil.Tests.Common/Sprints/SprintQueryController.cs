using System;
using System.Linq;
using System.Linq.Expressions;
using Agiil.Domain.Projects;
using Agiil.Domain.Sprints;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using CSF.Entities;

namespace Agiil.Tests.Sprints
{
  public class SprintQueryController : ISprintQueryController
  {
    readonly IRepository<Sprint> repo;
    readonly IRepository<Project> projectRepo;

    public bool DoesSprintExist(SprintSearchCriteria criteria = null)
    {
      var query = repo.Query();
      query = ApplyCriteria(query, criteria);
      return query.AnyCount();
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

    public SprintQueryController(IRepository<Sprint> repo, IRepository<Project> projectRepo)
    {
      if(projectRepo == null)
        throw new ArgumentNullException(nameof(projectRepo));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
      this.projectRepo = projectRepo;
    }
  }
}
