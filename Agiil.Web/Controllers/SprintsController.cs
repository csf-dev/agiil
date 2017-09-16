using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Controllers
{
  public class SprintsController : ControllerBase
  {
    readonly ISprintLister lister;

    public ActionResult Index(AdHocSprintListingRequest spec)
    {
      var request = Mapper.Map<ListSprintsRequest>(spec);
      var sprints = lister.GetSprints(request);
      var model = GetModel(spec, sprints);
      return View(model);
    }

    ListSprintModel GetModel(AdHocSprintListingRequest spec, IList<Sprint> sprints)
    {
      var model = ModelFactory.GetModel<ListSprintModel>();
      if(spec != null)
      {
        model.ShowingClosedSprints = spec.ShowClosedSprints;
      }

      model.Sprints = sprints.Select(x => Mapper.Map<SprintSummaryDto>(x)).ToList();

      return model;
    }

    public SprintsController(ControllerBaseDependencies deps, ISprintLister lister) : base(deps)
    {
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.lister = lister;
    }
  }
}
