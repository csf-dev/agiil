using System;
using System.Web.Mvc;
using Agiil.Domain.Projects;

namespace Agiil.Web.Controllers
{
    public class NewProjectController : Controller
    {
        private readonly Lazy<ICreatesProject> projectCreator;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CreateProjectRequest request)
        {
            projectCreator.Value.CreateNewProject(request);
            return RedirectToAction(nameof(Index), this.GetName());
        }

        public NewProjectController(Lazy<ICreatesProject> projectCreator)
        {
            this.projectCreator = projectCreator ?? throw new ArgumentNullException(nameof(projectCreator));
        }
    }
}
