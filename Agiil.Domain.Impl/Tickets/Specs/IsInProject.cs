using System;
using System.Linq.Expressions;
using Agiil.Domain.Projects;
using CSF.Entities;
using CSF.ORM;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
    public interface ISpecForTicketInProject : ISpecificationExpression<Ticket> { }

    public class IsInProject : ISpecForTicketInProject
    {
        readonly IIdentity<Project> projectId;
        readonly IEntityData data;

        public Expression<Func<Ticket, bool>> GetExpression()
        {
            var project = data.Theorise(projectId);
            return x => x.Project == project;
        }

        public IsInProject(IIdentity<Project> projectId, IEntityData data)
        {
            this.projectId = projectId ?? throw new ArgumentNullException(nameof(projectId));
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
