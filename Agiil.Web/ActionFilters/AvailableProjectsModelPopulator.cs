using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Auth;
using Agiil.Domain.Projects;
using Agiil.Web.Models.Projects;
using AutoMapper;
using CSF.Entities;

namespace Agiil.Web.ActionFilters
{
    public class AvailableProjectsModelPopulator : IActionFilter
    {
        readonly IGetsListOfProjects projectsProvider;
        readonly IGetsCurrentProject currentProjectProvider;
        readonly IMapper mapper;
        readonly ICurrentUserReader userReader;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(!(filterContext.Result is ViewResult viewResult)) return;
            if(!(viewResult.Model is IHasAvailableProjects availableProjectsModel)) return;
            if(userReader.GetCurrentUser() == null) return;

            availableProjectsModel.AvailableProjects = GetAvailableProjects();
        }

        AvailableProjectsModel GetAvailableProjects()
        {
            var projects = projectsProvider.GetsProjects();
            var mappedProjects = mapper.Map<IList<Project>,IList<AvailableProjectModel>>(projects);
            var currentProject = currentProjectProvider.GetCurrentProject();

            var current = mappedProjects.FirstOrDefault(x => Equals(x.Identity, currentProject.GetIdentity()));
            if(current != null) current.IsCurrent = true;

            return new AvailableProjectsModel {
                Projects = mappedProjects,
            };
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

        public AvailableProjectsModelPopulator(IGetsListOfProjects projectsProvider,
                                               IGetsCurrentProject currentProjectProvider,
                                               IMapper mapper,
                                               ICurrentUserReader userReader)
        {
            this.projectsProvider = projectsProvider ?? throw new ArgumentNullException(nameof(projectsProvider));
            this.currentProjectProvider = currentProjectProvider ?? throw new ArgumentNullException(nameof(currentProjectProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
        }
    }
}
