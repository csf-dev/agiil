using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.Web.ApiControllers
{
  public class SprintsController : ApiController
  {
    readonly ISprintLister lister;
    readonly Lazy<IMapper> mapper;

    public IList<SprintSummaryDto> Get()
    {
      var sprints = lister.GetSprints(new ListSprintsRequest());
      return sprints.Select(x => mapper.Value.Map<SprintSummaryDto>(x)).ToList();
    }

    public SprintsController(Lazy<IMapper> mapper,
                             ISprintLister lister)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.lister = lister;
      this.mapper = mapper;
    }
  }
}
