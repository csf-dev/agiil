using System;
using System.Web.Mvc;
using Agiil.Domain.Projects;
using Agiil.Web.ActionFilters;
using Agiil.Web.Models.Projects;
using AutoMapper;

namespace Agiil.Web.Controllers
{
    [RequireAppAdmin]
    public class NewProjectController : Controller
    {
        const string NewProjectKey = "Create project model";

        readonly Lazy<ICreatesProject> projectCreator;
        readonly Lazy<IMapper> mapper;

        public ActionResult Index()
        {
            var model = TempData.TryGet<CreateProjectModel>(NewProjectKey) ?? new CreateProjectModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CreateProjectModel model)
        {
            var request = mapper.Value.Map<CreateProjectRequest>(model);
            var result = projectCreator.Value.CreateNewProject(request);

            if(!result.IsSuccess)
            {
                model.Response = result;
                TempData.Add(NewProjectKey, model);
            }

            return RedirectToAction(nameof(Index), this.GetName());
        }

        public NewProjectController(Lazy<ICreatesProject> projectCreator,
                                    Lazy<IMapper> mapper)
        {
            this.projectCreator = projectCreator ?? throw new ArgumentNullException(nameof(projectCreator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
