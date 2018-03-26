using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain.Sprints;
using Agiil.Web.Models.Sprints;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.Controllers
{
  public class SprintController : Controller
  {
    const string
      EditSprintModelKey = "Edit sprint model",
      SuccessfulEditKey = "Successful edit";


    readonly Lazy<ISprintDetailService> detailService;
    readonly Lazy<ISprintEditor> editor;
    readonly IMapper mapper;

    public ActionResult Index(IIdentity<Sprint> id)
    {
      var sprint = detailService.Value.GetSprint(id);

      if(ReferenceEquals(sprint, null))
        return HttpNotFound();

      var model = new ViewSprintModel();
      model.Sprint = mapper.Map<SprintDetailDto>(sprint);
      return View(model);
    }

    [HttpGet]
    public ActionResult Edit(IIdentity<Sprint> id)
    {
      var sprint = detailService.Value.GetSprint(id);

      if(ReferenceEquals(sprint, null))
        return HttpNotFound();

      var response = TempData.TryGet<Models.Sprints.EditSprintResponse>(EditSprintModelKey);
      var model = CreateModel();
      model.Response = response;
      model.Sprint = mapper.Map<SprintDetailDto>(sprint);
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(EditSprintSpecification spec)
    {
      var request = mapper.Map<EditSprintRequest>(spec);
      var response = editor.Value.Edit(request);

      if(response.IdIsInvalid)
        return HttpNotFound();

      TempData.Clear();

      if(response.IsSuccess)
      {
        TempData.Add(SuccessfulEditKey, true);
        return RedirectToAction(nameof(Index), new { id = spec.Id });
      }

      var responseModel = mapper.Map<Models.Sprints.EditSprintResponse>(response);
      TempData.Add(EditSprintModelKey, responseModel);

      return RedirectToAction(nameof(Edit), new { id = spec.Id });
    }

    EditSprintModel CreateModel()
    {
      return new EditSprintModel();
    }

    public SprintController(Lazy<ISprintDetailService> detailService,
                            Lazy<ISprintEditor> editor,
                            IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(detailService == null)
        throw new ArgumentNullException(nameof(detailService));
      this.mapper = mapper;
      this.detailService = detailService;
      this.editor = editor;
    }
  }
}
