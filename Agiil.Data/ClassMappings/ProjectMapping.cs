using System;
using Agiil.Data.MappingProviders;
using Agiil.Domain.Auth;
using Agiil.Domain.Projects;
using NHibernate.Mapping.ByCode;

namespace Agiil.Data.ClassMappings
{
    public class ProjectMapping : IConventionMapping
    {
        readonly IDbNameFormatter nameFormatter;

        public void ApplyMapping(ConventionModelMapper mapper)
        {
            mapper.Class<Project>(map => {
                map.Set(x => x.Contributors, set => {
                    set.Table(nameFormatter.GetManyToManyTableName(typeof(Project), UserMapping.Contributor, typeof(User)));
                });

                map.Set(x => x.Administrators, set => {
                    set.Table(nameFormatter.GetManyToManyTableName(typeof(Project), UserMapping.Administrator, typeof(User)));
                });
            });
        }

        public ProjectMapping(IDbNameFormatter nameFormatter)
        {
            this.nameFormatter = nameFormatter ?? throw new ArgumentNullException(nameof(nameFormatter));
        }
    }
}