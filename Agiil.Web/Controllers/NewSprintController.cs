using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;

namespace Agiil.Web.Controllers
{
  public class NewSprintController : ControllerBase
  {
    const string 
      NewSprintResultKey = "New sprint result",
      NewSprintSpecKey = "New sprint specification";

    readonly Lazy<ISprintCreator> creator;

    [HttpGet]
    public ActionResult Index()
    {
      var model = GetModel();
      return View(model);
    }

    [HttpGet]
    public ActionResult Created()
    {
      var model = GetModel();

      if(model.Result == null)
      {
        return RedirectToAction(nameof(Index));
      }

      return View(model);
    }

    [HttpPost]
    public ActionResult Index(NewSprintSpecification spec)
    {
      var request = Mapper.Map<CreateSprintRequest>(spec);
      var response = creator.Value.Create(request);
      var result = Mapper.Map<NewSprintResult>(response);

      TempData.Clear();
      TempData.Add(NewSprintResultKey, result);

      if(result.IsSuccess)
      {
        return RedirectToAction(nameof(Created));
      }

      TempData.Add(NewSprintSpecKey, spec);
      return RedirectToAction(nameof(Index));
    }

    NewSprintModel GetModel()
    {
      var model = ModelFactory.GetModel<NewSprintModel>();
      model.Result = GetTempData<NewSprintResult>(NewSprintResultKey);
      model.Specification = GetTempData<NewSprintSpecification>(NewSprintSpecKey);
      return model;
    }

    public NewSprintController(ControllerBaseDependencies deps,
                               Lazy<ISprintCreator> creator) : base(deps)
    {
      if(creator == null)
        throw new ArgumentNullException(nameof(creator));
      this.creator = creator;
    }
  }
}
