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

        public CreateProjectResponse CreateNewProject(CreateProjectRequest request)
        {
            var project = mapper.Map<Project>(request);
            data.Add(project);
            return new CreateProjectResponse { ProjectIdentity = project.GetIdentity() };
        }

        public ProjectCreator(IEntityData data,
                              IMapper mapper)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
