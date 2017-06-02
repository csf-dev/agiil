using System;
using System.Collections.Generic;
using System.Linq;
using CSF.Data.Entities;

namespace Agiil.Domain.Sprints
{
  public class SprintLister : ISprintLister
  {
    readonly IRepository<Sprint> repo;

    public IList<Sprint> GetSprints()
    {
      return GetSprints(null);
    }

    public IList<Sprint> GetSprints(ListSprintsRequest request)
    {
      var query = repo.Query();
      query = ApplyFilters(query, request?? new ListSprintsRequest());
      return query
        .OrderBy(x => x.StartDate.HasValue? x.StartDate : x.CreationDate)
        .ToList();
      
    }

    IQueryable<Sprint> ApplyFilters(IQueryable<Sprint> query, ListSprintsRequest request)
    {
      if(ReferenceEquals(request, null))
        return query;

      if(!request.ShowOpenSprints)
        query = query.Where(x => x.Closed);

      if(!request.ShowClosedSprints)
        query = query.Where(x => !x.Closed);

      return query;
    }

    public SprintLister(IRepository<Sprint> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
