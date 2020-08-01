using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;

namespace Agiil.Web.Controllers
{
  public class SprintsController : Controller
  {
    readonly ISprintLister lister;
    readonly IMapper mapper;

    public ActionResult Index(AdHocSprintListingRequest spec)
    {
      var request = mapper.Map<ListSprintsRequest>(spec);
      var sprints = lister.GetSprints(request);
      var model = GetModel(spec, sprints);
      return View(model);
    }

    ListSprintModel GetModel(AdHocSprintListingRequest spec, IList<Sprint> sprints)
    {
      return new ListSprintModel {
          ShowingClosedSprints = (spec?.ShowClosedSprints).GetValueOrDefault(),
          Sprints = sprints.Select(x => mapper.Map<SprintSummaryDto>(x)).ToList(),
      };
    }

    public SprintsController(ISprintLister lister,
                             IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.mapper = mapper;
      this.lister = lister;
    }
  }
}
