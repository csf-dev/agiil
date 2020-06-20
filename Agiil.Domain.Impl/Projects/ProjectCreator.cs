using System;
using AutoMapper;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class ProjectCreator : ICreatesProject
    {
        readonly IEntityData data;
        readonly IMapper mapper;
        private readonly Func<CreateProjectResponse> responseFactory;

        public CreateProjectResponse CreateNewProject(CreateProjectRequest request)
        {
            var project = mapper.Map<Project>(request);
            data.Add(project);
            var response = responseFactory();
            response.ProjectIdentity = project.GetIdentity();
            return response;
        }

        public ProjectCreator(IEntityData data,
                              IMapper mapper,
                              Func<CreateProjectResponse> responseFactory)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.responseFactory = responseFactory ?? throw new ArgumentNullException(nameof(responseFactory));
        }
    }
}
