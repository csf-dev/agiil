using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Agiil.Domain.Auth;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Projects;
using Agiil.Web.Models.Projects;
using AutoMapper;
using CSF.Entities;
using log4net;

namespace Agiil.Web.ActionFilters
{
    public class AvailableProjectsModelPopulator : IActionFilter
    {
        readonly IGetsListOfProjects projectsProvider;
        readonly IGetsCurrentProject currentProjectProvider;
        readonly IMapper mapper;
        readonly ICurrentUserReader userReader;
        readonly IDeterminesIfCurrentUserHasCapability capabilityProvider;
        private readonly ILog logger;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(!(filterContext.Result is ViewResult viewResult)) return;

            try
            {
                if(userReader.GetCurrentUser() == null) return;
                viewResult.ViewBag.AvailableProjects = GetAvailableProjects();
            }
            catch(Exception e)
            {
                logger.Warn("Caught exception whilst populating state; as this is non-critical it is being ignored.  The exception will be recorded at DEBUG level.");
                logger.Debug(e);
            }
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
                CanCreateSprints = capabilityProvider.DoesUserHaveCapability(ProjectCapability.CreateSprint,
                                                                             currentProject.GetIdentity()),
            };
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) { /* No-op */ }

        public AvailableProjectsModelPopulator(IGetsListOfProjects projectsProvider,
                                               IGetsCurrentProject currentProjectProvider,
                                               IMapper mapper,
                                               ICurrentUserReader userReader,
                                               IDeterminesIfCurrentUserHasCapability capabilityProvider,
                                               ILog logger)
        {
            this.projectsProvider = projectsProvider ?? throw new ArgumentNullException(nameof(projectsProvider));
            this.currentProjectProvider = currentProjectProvider ?? throw new ArgumentNullException(nameof(currentProjectProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
            this.capabilityProvider = capabilityProvider ?? throw new ArgumentNullException(nameof(capabilityProvider));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
