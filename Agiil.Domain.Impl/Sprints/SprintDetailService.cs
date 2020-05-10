using System;
using System.Linq;
using CSF.ORM;
using CSF.Entities;

namespace Agiil.Domain.Sprints
{
  public class SprintDetailService : ISprintDetailService
  {
    readonly IEntityData repo;

    public Sprint GetSprint(IIdentity<Sprint> identity)
    {
      if(ReferenceEquals(identity, null))
        return null;

      var theory = repo.Theorise(identity);
      return repo
        .Query<Sprint>()
        .Where(x => x == theory)
        .FetchChild(x => x.Project)
        .FetchChildren(x => x.Tickets)
        .ThenFetchGrandchild(x => x.Type)
        .ToList()
        .SingleOrDefault();
    }

    public SprintDetailService(IEntityData repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
