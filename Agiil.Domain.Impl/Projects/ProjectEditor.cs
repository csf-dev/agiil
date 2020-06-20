using System;
using AutoMapper;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class ProjectEditor : IEditsProject
    {
        readonly IMapper mapper;
        readonly IEntityData data;
        readonly Func<EditProjectResponse> responseFactory;

        public EditProjectResponse EditProject(EditProjectRequest request)
        {
            var project = data.Get(request.Identity);
            if(project == null) throw new ArgumentException($"The project {request.Identity} does not exist.", nameof(request));

            mapper.Map(request, project);

            var response = responseFactory();
            response.Project = project;
            return response;
        }

        public ProjectEditor(IMapper mapper,
                             IEntityData data,
                             Func<EditProjectResponse> responseFactory)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.responseFactory = responseFactory ?? throw new ArgumentNullException(nameof(responseFactory));
        }
    }
}
