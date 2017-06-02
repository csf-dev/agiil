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
    const string
      EditSprintModelKey = "Edit sprint model",
      SuccessfulEditKey = "Successful edit";


    readonly Lazy<ISprintDetailService> detailService;
    readonly Lazy<ISprintEditor> editor;

    public ActionResult Index(IIdentity<Sprint> id)
    {
      var sprint = detailService.Value.GetSprint(id);

      if(ReferenceEquals(sprint, null))
        return HttpNotFound();

      var model = ModelFactory.GetModel<ViewSprintModel>();
      model.Sprint = Mapper.Map<SprintDetailDto>(sprint);
      return View(model);
    }

    [HttpGet]
    public ActionResult Edit(IIdentity<Sprint> id)
    {
      var sprint = detailService.Value.GetSprint(id);

      if(ReferenceEquals(sprint, null))
        return HttpNotFound();

      var model = GetTempData<EditSprintModel>(EditSprintModelKey)?? CreateModel();
      model.SprintDetail = Mapper.Map<SprintDetailDto>(sprint);
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(EditSprintSpecification spec)
    {
      var request = Mapper.Map<EditSprintRequest>(spec);
      var response = editor.Value.Edit(request);

      if(response.IdIsInvalid)
        return HttpNotFound();

      TempData.Clear();

      if(response.IsSuccess)
      {
        TempData.Add(SuccessfulEditKey, true);
        return RedirectToAction(nameof(Index), new { id = spec.Id });
      }

      var responseModel = Mapper.Map<Models.Sprints.EditSprintResponse>(response);
      TempData.Add(EditSprintModelKey, responseModel);

      return RedirectToAction(nameof(Edit), new { id = spec.Id });
    }

    EditSprintModel CreateModel()
    {
      return ModelFactory.GetModel<EditSprintModel>();
    }

    public SprintController(ControllerBaseDependencies deps,
                            Lazy<ISprintDetailService> detailService,
                            Lazy<ISprintEditor> editor) : base(deps)
    {
      if(editor == null)
        throw new ArgumentNullException(nameof(editor));
      if(detailService == null)
        throw new ArgumentNullException(nameof(detailService));
      this.detailService = detailService;
      this.editor = editor;
    }
  }
}
