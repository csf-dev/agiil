using System;
using System.Linq;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
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
        .Fetch(x => x.Project)
        .FetchMany(x => x.Tickets)
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
