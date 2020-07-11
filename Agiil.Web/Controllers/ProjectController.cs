using System;
using System.Web.Mvc;
using Agiil.Domain.Projects;
using Agiil.Web.ActionFilters;
using Agiil.Web.Models.Projects;
using AutoMapper;
using CSF.ORM;

namespace Agiil.Web.Controllers
{
    [RequireAppAdmin]
    public class ProjectController : Controller
    {
        const string EditProjectKey = "Edit project model";

        readonly Lazy<IGetsProject> projectProvider;
        readonly Lazy<IMapper> mapper;
        readonly Lazy<IEditsProject> projectEditor;
        private readonly Lazy<IEntityData> data;

        public ActionResult Index(string id)
        {
            var project = projectProvider.Value.GetProject(id);
            if(project == null) return HttpNotFound();

            var dto = mapper.Value.Map<ProjectDescriptionDto>(project);
            return View(new ViewProjectModel { Project = dto });
        }

        public ActionResult Edit(string id)
        {
            var model = TempData.TryGet<EditProjectModel>(EditProjectKey);
            if(model == null)
            {
                var project = projectProvider.Value.GetProject(id);
                if(project == null) return HttpNotFound();

                model = mapper.Value.Map<EditProjectModel>(project);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProjectModel model)
        {
            var request = mapper.Value.Map<EditProjectRequest>(model);
            var result = projectEditor.Value.EditProject(request);

            if(result?.IsSuccess == true)
                return RedirectToAction(nameof(Index), new { id = result.Project.Code });

            var project = data.Value.Get(model.Identity);
            if(project == null) return HttpNotFound();

            model.Request = request;
            model.Response = result;
            TempData.Add(EditProjectKey, model);
            return RedirectToAction(nameof(Edit), new { id = project.Code });
        }

        public ProjectController(Lazy<IGetsProject> projectProvider,
                                 Lazy<IMapper> mapper,
                                 Lazy<IEditsProject> projectEditor,
                                 Lazy<IEntityData> data)
        {
            this.projectProvider = projectProvider ?? throw new ArgumentNullException(nameof(projectProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.projectEditor = projectEditor ?? throw new ArgumentNullException(nameof(projectEditor));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
