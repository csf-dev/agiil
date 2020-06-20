using System;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Projects;
using Agiil.Web.ActionFilters;
using Agiil.Web.Models.Projects;
using AutoMapper;

namespace Agiil.Web.Controllers
{
    [RequireAppAdmin]
    public class ProjectsController : Controller
    {
        readonly IMapper mapper;
        readonly Lazy<IGetsListOfProjects> projectLister;

        public ActionResult Index()
        {
            var projects = projectLister.Value.GetsProjects();
            var model = new ProjectsListModel {
                Projects = projects.Select(mapper.Map<ProjectDescriptionDto>).ToList()
            };
            return View(model);
        }

        public ProjectsController(IMapper mapper, Lazy<IGetsListOfProjects> projectLister)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.projectLister = projectLister ?? throw new ArgumentNullException(nameof(projectLister));
        }
    }
}
