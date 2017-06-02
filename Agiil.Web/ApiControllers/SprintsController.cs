using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.ApiControllers
{
  public class SprintsController : ApiControllerBase
  {
    readonly ISprintLister lister;

    public IList<SprintSummaryDto> Get()
    {
      var sprints = lister.GetSprints();
      return sprints.Select(x => Mapper.Map<SprintSummaryDto>(x)).ToList();
    }

    public SprintsController(ApiControllerBaseDependencies deps,
                             ISprintLister lister) : base(deps)
    {
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.lister = lister;
    }
  }
}
