using System;
using Agiil.Domain.Projects;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Entities;
using CSF.Specifications;

namespace Agiil.Domain.TicketSearch
{
    public class CurrentProjectCriterionAddingSpecProviderDecorator : IGetsTicketSpecification
    {
        readonly Search search;
        readonly IGetsTicketSpecification wrapped;
        readonly IGetsWhetherSearchContainsProjectCriteria projectCriteriaDetector;
        readonly IGetsCurrentProject projectProvider;
        readonly Func<IIdentity<Project>, ISpecForTicketInProject> projectSpecFactory;

        public ISpecificationExpression<Ticket> GetSpecification()
        {
            var wrappedResult = wrapped.GetSpecification();

            projectCriteriaDetector.Visit(search);
            var hasProjectCriteria = projectCriteriaDetector.DoesSearchContainAnyProjectCriteria();
            if(hasProjectCriteria) return wrappedResult;

            var project = projectProvider.GetCurrentProject();
            var spec = projectSpecFactory(project.GetIdentity());
            return wrappedResult.And(spec);
        }

        public CurrentProjectCriterionAddingSpecProviderDecorator(Search search,
                                                                  IGetsTicketSpecification wrapped,
                                                                  IGetsWhetherSearchContainsProjectCriteria projectCriteriaDetector,
                                                                  IGetsCurrentProject projectProvider,
                                                                  Func<IIdentity<Project>,ISpecForTicketInProject> projectSpecFactory)
        {
            this.search = search ?? throw new ArgumentNullException(nameof(search));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
            this.projectCriteriaDetector = projectCriteriaDetector ?? throw new ArgumentNullException(nameof(projectCriteriaDetector));
            this.projectProvider = projectProvider ?? throw new ArgumentNullException(nameof(projectProvider));
            this.projectSpecFactory = projectSpecFactory ?? throw new ArgumentNullException(nameof(projectSpecFactory));
        }
    }
}
