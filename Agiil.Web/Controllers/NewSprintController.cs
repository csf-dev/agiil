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
  public class NewSprintController : Controller
  {
    const string 
      NewSprintResultKey = "New sprint result",
      NewSprintSpecKey = "New sprint specification";

    readonly Lazy<ISprintCreator> creator;
    readonly IMapper mapper;

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
      var request = mapper.Map<CreateSprintRequest>(spec);
      var response = creator.Value.Create(request);
      var result = mapper.Map<NewSprintResult>(response);

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
      var model = new NewSprintModel();
      model.Result = TempData.TryGet<NewSprintResult>(NewSprintResultKey);
      model.Specification = TempData.TryGet<NewSprintSpecification>(NewSprintSpecKey);
      return model;
    }

    public NewSprintController(Lazy<ISprintCreator> creator,
                              IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(creator == null)
        throw new ArgumentNullException(nameof(creator));
      this.mapper = mapper;
      this.creator = creator;
    }
  }
}
