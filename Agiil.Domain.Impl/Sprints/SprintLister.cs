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
      return repo
        .Query()
        .OrderBy(x => x.StartDate.HasValue? x.StartDate : x.CreationDate)
        .ToList();
    }

    public SprintLister(IRepository<Sprint> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
