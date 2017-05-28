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

    public ActionResult Index()
    {
      var sprints = lister.GetSprints();
      var model = ModelFactory.GetModel<ListSprintModel>();
      model.Sprints = sprints.Select(x => Mapper.Map<SprintSummaryDto>(x)).ToList();

      return View(model);
    }

    public SprintsController(ControllerBaseDependencies deps, ISprintLister lister) : base(deps)
    {
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.lister = lister;
    }
  }
}
