using System;
using System.Web.Mvc;
using Agiil.Domain.Projects;
using Agiil.Web.Models.Projects;
using AutoMapper;

namespace Agiil.Web.Controllers
{
    public class NewProjectController : Controller
    {
        private readonly Lazy<ICreatesProject> projectCreator;
        private readonly Lazy<IMapper> mapper;

        public ActionResult Index()
        {
            return View(new CreateProjectModel());
        }

        [HttpPost]
        public ActionResult Index(CreateProjectModel model)
        {
            var request = mapper.Value.Map<CreateProjectRequest>(model);
            projectCreator.Value.CreateNewProject(request);
            return RedirectToAction(nameof(Index), this.GetName());
        }

        public NewProjectController(Lazy<ICreatesProject> projectCreator, Lazy<IMapper> mapper)
        {
            this.projectCreator = projectCreator ?? throw new ArgumentNullException(nameof(projectCreator));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
