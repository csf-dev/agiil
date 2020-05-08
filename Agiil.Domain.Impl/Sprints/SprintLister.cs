using System;
using System.Collections.Generic;
using System.Linq;
using CSF.ORM;

namespace Agiil.Domain.Sprints
{
  public class SprintLister : ISprintLister
  {
    readonly IEntityData queryProvider;

    public IList<Sprint> GetSprints()
    {
      return GetSprints(null);
    }

    public IList<Sprint> GetSprints(ListSprintsRequest request)
    {
      var query = queryProvider.Query<Sprint>();
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

    public SprintLister(IEntityData query)
    {
      if(query == null)
        throw new ArgumentNullException(nameof(query));
      this.queryProvider = query;
    }
  }
}
