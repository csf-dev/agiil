using System;
using AutoMapper;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class ProjectCreator : ICreatesProject
    {
        readonly IGetsTransaction transactionCreator;
        readonly IEntityData data;
        readonly IMapper mapper;

        public Project CreateNewProject(CreateProjectRequest request)
        {
            var project = mapper.Map<Project>(request);
            project.NextAvailableTicketNumber = 1;

            using(var tran = transactionCreator.GetTransaction())
            {
                data.Add(project);
                tran.Commit();
            }

            return project;
        }

        public ProjectCreator(IGetsTransaction transactionCreator,
                              IEntityData data,
                              IMapper mapper)
        {
            this.transactionCreator = transactionCreator ?? throw new ArgumentNullException(nameof(transactionCreator));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
