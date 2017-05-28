using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class SprintController : ControllerBase
  {
    readonly ISprintDetailService detailService;

    public ActionResult Index(IIdentity<Sprint> id)
    {
      var sprint = detailService.GetSprint(id);

      if(ReferenceEquals(sprint, null))
        return HttpNotFound();

      var model = ModelFactory.GetModel<ViewSprintModel>();
      model.Sprint = Mapper.Map<SprintDetailDto>(sprint);
      return View(model);
    }

    public SprintController(ControllerBaseDependencies deps,
                            ISprintDetailService detailService) : base(deps)
    {
      if(detailService == null)
        throw new ArgumentNullException(nameof(detailService));
      this.detailService = detailService;
    }
  }
}
